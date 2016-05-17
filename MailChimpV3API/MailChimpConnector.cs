using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using MailChimpV3API.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using RestSharp;
using RestSharp.Authenticators;

namespace MailChimpV3API
{
    internal class MailChimpConnector : IMailChimpConnector
    {
        private Policy _retryPolicy;
        private Policy _retryPolicyAsync;
        private const string InvalidApiKeyMessage = "API key is not valid. Must be a valid v3.0 Mailchimp API key";

        public MailChimpConnector(string apiKey)
        {
            ParseApiKey(apiKey);
            CreateRetryPolicies();
        }

        private void CreateRetryPolicies()
        {
            var policyBuilder = Policy
                .Handle<WebException>();

            Func<int, TimeSpan> sleepDurationProvider = retryAttempt =>
                                         TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));

            _retryPolicy = policyBuilder
                .WaitAndRetry(5, sleepDurationProvider);

            _retryPolicyAsync = policyBuilder
                .WaitAndRetryAsync(5, sleepDurationProvider);
        }

        public MailChimpConnector(string accessToken, string dataCentrePrefix)
        {
            AccessToken = accessToken;
            DataCentrePrefix = dataCentrePrefix;
            CreateRetryPolicies();
        }

        internal string AccessToken { get; private set; }

        internal string DataCentrePrefix { get; private set; }

        public TResult Delete<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) where TResult : new()
        {
            return Execute<TResult>(action, queryStringParams, body, Method.DELETE);
        }

        public async Task<TResult> DeleteAsync<TResult>(string action,
                                                        Dictionary<string, string> queryStringParams = null,
                                                        object body = null,
                                                        CancellationToken cancellationToken = default(CancellationToken)) where TResult : new()
        {
            return await ExecuteAsyncImpl<TResult>(CreateRequest(action, queryStringParams, body, Method.DELETE), cancellationToken);
        }

        public TResult Execute<TResult>(string action, Dictionary<string, string> queryStringParams, object body, Method method) where TResult : new()
        {
            var client = CreateClient();
            var request = CreateRequest(action, queryStringParams, body, method);

            var response = _retryPolicy.Execute(() => client.Execute<TResult>(request));

            return response.Data;
        }

        public Task<TResult> ExecuteAsync<TResult>(string action,
                                                   MailChimpFieldFilter filter,
                                                   CancellationToken cancellationToken = default(CancellationToken)) where TResult : new()
        {
            var request = CreateGetRequest(action, filter);

            return ExecuteAsyncImpl<TResult>(request, cancellationToken);
        }

        public async Task<IEnumerable<TResult>> ExportAsync<TResult>(
            string action, 
            Dictionary<string, string> queryStringParams, 
            bool hasHeader = false, 
            TextWriter log = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            log = log ?? TextWriter.Null;

            var client = CreateClient("export/1.0", false);

            queryStringParams.Add("apikey", AccessToken);

            log.WriteLine("Creating request");

            var request = CreateRequest(action, queryStringParams, null, Method.GET);

            log.WriteLine("Executing request");

            var response = await _retryPolicyAsync.ExecuteAsync(async () =>
            {
                var result = await client.ExecuteTaskAsync(request, cancellationToken);

                if (result == null)
                {
                    throw new NullReferenceException("Result from MailChimp call is null");
                }

                return result;
            });

            var content = response.Content;

            if (content == null || content.Contains('\n') == false)
            {
                log.WriteLine("Bad response received from MailChimp:");

                if (content != null)
                {
                    log.WriteLine(content);
                }

                return Enumerable.Empty<TResult>();
            }

            log.WriteLine("Response received from MailChimp with length: " + content.Length);

            var lines = content.Split('\n');

            return GetObjectsFromArray<TResult>(lines, hasHeader);
        }

        private static IEnumerable<T> GetObjectsFromArray<T>(IReadOnlyList<string> readAllLines, bool hasHeader)
        {
            var header = new List<string>();

            var skipped = 0;

            for (var i = 0; i < readAllLines.Count; i++)
            {
                var line = readAllLines[i];

                if (hasHeader)
                {
                    var data = JsonConvert.DeserializeObject<List<string>>(line);

                    if (data == null)
                    {
                        continue;
                    }

                    // skip header
                    if (i == 0)
                    {
                        header = data;

                        header[0] = "EmailAddress";

                        continue;
                    }

                    if (data.Count != header.Count)
                    {
                        skipped++;
                        continue;
                    }

                    var json = new JObject();

                    for (var j = 0; j < header.Count; j++)
                    {
                        var propertyName = header[j].Replace(" ", string.Empty);

                        if (json.Properties().Any(x => x.Name.Equals(propertyName)))
                        {
                            continue;
                        }

                        json.Add(propertyName, data[j]);
                    }

                    yield return json.ToObject<T>();
                    continue;
                }

                yield return JsonConvert.DeserializeObject<T>(line);
            }
        }

        public TResult Get<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) where TResult : new()
        {
            return Execute<TResult>(action, queryStringParams, body, Method.GET);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult, TCollection>(string action,
                                                                                  MailChimpCollectionFilterBase filter,
                                                                                  Func<TCollection, IEnumerable<TResult>> transformResult,
                                                                                  CancellationToken cancellationToken = default(CancellationToken),
                                                                                  Func<int, int, Task> progressCallback = null)
            where TCollection : class, IMailChimpCollection, new()
        {
            if (filter.IncludeFields.Any())
            {
                const string Totalitems = "total_items";
                if (filter.IncludeFields.Any(i => i.Equals(Totalitems)) == false)
                {
                    filter.IncludeFields = filter.IncludeFields.Union(new[] { Totalitems });
                }
            }

            // get the first page so we can see the total
            var firstPage = await GetAsync<TCollection>(action, filter, cancellationToken);

            if (firstPage == null)
            {
                return Enumerable.Empty<TResult>();
            }

            var total = firstPage.TotalItems;
            var offset = filter.Offset;

            var firstPageMembers = transformResult(firstPage);

            var progress = firstPageMembers.Count();

            if (progressCallback != null)
            {
                await progressCallback(progress, total);
            }

            Func<MailChimpFieldFilter, Task<IEnumerable<TResult>>> fetch = async listFilter =>
            {
                var result = await GetAsync<TCollection>(action, listFilter, cancellationToken);

                if (result == null)
                {
                    return null;
                }

                var collection = transformResult(result);

                Interlocked.Add(ref progress, collection.Count());

                if (progressCallback != null)
                {
                    await progressCallback(progress, total);
                }

                return collection == null ? null : collection;
            };

            var block = new TransformBlock<MailChimpFieldFilter, IEnumerable<TResult>>(
                fetch,
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5 });

            var buffer = new BufferBlock<IEnumerable<TResult>>();
            block.LinkTo(buffer);

            while (offset < total)
            {
                var listMembersFilter = filter.Clone();
                listMembersFilter.Offset = offset;

                await block.SendAsync(listMembersFilter, cancellationToken);

                offset += filter.Count;
            }

            block.Complete();
            await block.Completion;

            IList<IEnumerable<TResult>> members;
            buffer.TryReceiveAll(out members);

            if (members == null)
            {
                return firstPageMembers;
            }

            return members.Where(m => m != null).SelectMany(x => x);
        }

        public async Task<TResult> GetAsync<TResult>(string action,
                                                     MailChimpFieldFilter filter = null,
                                                     CancellationToken cancellationToken = default(CancellationToken)) where TResult : new()
        {
            return await ExecuteAsync<TResult>(action, filter, cancellationToken);
        }

        public TResult Patch<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) where TResult : new()
        {
            return Execute<TResult>(action, queryStringParams, body, Method.PATCH);
        }

        public async Task<TResult> PatchAsync<TResult>(string action,
                                                       Dictionary<string, string> queryStringParams = null,
                                                       object body = null,
                                                       CancellationToken cancellationToken = default(CancellationToken)) where TResult : new()
        {
            return await ExecuteAsyncImpl<TResult>(CreateRequest(action, queryStringParams, body, Method.PATCH), cancellationToken);
        }

        public TResult Post<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) where TResult : new()
        {
            return Execute<TResult>(action, queryStringParams, body, Method.POST);
        }

        public async Task<TResult> PostAsync<TResult>(string action,
                                                      Dictionary<string, string> queryStringParams = null,
                                                      object body = null,
                                                      CancellationToken cancellationToken = default(CancellationToken)) where TResult : new()
        {
            return await ExecuteAsyncImpl<TResult>(CreateRequest(action, queryStringParams, body, Method.POST), cancellationToken);
        }

        private static Exception BuildErrorFromResponse(string responseText)
        {
            var error = JsonConvert.DeserializeObject<MailChimpApiProblem>(responseText);

            // var mailchimpErrorDocPrefix = "http://kb.mailchimp.com/api/error-docs/";
            switch (Path.GetFileName(error.Type))
            {
                case "400-bad-request":
                    return new BadRequestException(error);

                case "400-invalid-action":
                    return new InvalidActionException(error);

                case "400-invalid-resource":
                    return new InvalidResourceException(error);

                case "400-json-parse-error":
                    return new JSONParseErrorException(error);

                case "401-api-key-invalid":
                    return new APIKeyInvalidException(error);

                case "401-api-key-missing":
                    return new APIKeyMissingException(error);

                case "403-forbidden":
                    return new ForbiddenException(error);

                case "403-user-disabled":
                    return new UserDisabledException(error);

                case "403-wrong-datacenter":
                    return new WrongDataCentreException(error);

                case "404-resource-not-found":
                    return new ResourceNotFoundException(error);

                case "405-method-not-allowed":
                    return new MethodNotAllowedException(error);

                case "414-resource-nesting-too-deep":
                    return new ResourceNestingTooDeepException(error);

                case "422-invalid-method-override":
                    return new InvalidMethodOverrideException(error);

                case "429-too-many-requests":
                    return new TooManyRequestsException(error);

                case "422-requested-fields-invalid":
                    return new RequestedFieldsInvalidException(error);

                case "500-internal-server-error":
                    return new InternalServerErrorException(error);

                case "503-compliance-related":
                    return new ComplianceRelatedException(error);

                default:
                    return new MailChimpException(error);
            }
        }

        private static IRestRequest CreateGetRequest(string action, MailChimpFieldFilter filter = null)
        {
            Dictionary<string, string> queryStringParams = null;
            if (filter != null)
            {
                var filterString = JsonConvert.SerializeObject(filter, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var filterDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(filterString);

                queryStringParams = filterDictionary.Where(x => x.Value != null).ToDictionary(x => x.Key, x => x.Value);
            }

            return CreateRequest(action, queryStringParams, null, Method.GET);
        }

        private static IRestRequest CreateRequest(string action, Dictionary<string, string> queryStringParams, object body, Method method)
        {
            ServicePointManager.DefaultConnectionLimit = 10;

            var request = new RestRequest(action, method) { RequestFormat = DataFormat.Json, JsonSerializer = new JsonSerializer() };

            if (queryStringParams != null && queryStringParams.Any())
            {
                foreach (var key in queryStringParams.Keys)
                {
                    request.AddParameter(key, queryStringParams[key], ParameterType.QueryString);
                }
            }

            if (body != null)
            {
                request.AddBody(body);
            }

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.Timeout = (int)TimeSpan.FromSeconds(200).TotalMilliseconds;

            request.OnBeforeDeserialization = response =>
            {
                if (response.ContentType.Contains("application/problem+json"))
                {
                    throw BuildErrorFromResponse(response.Content);
                }
            };

            return request;
        }

        private RestClient CreateClient(string api = "3.0", bool useOAuth = true)
        {
            if (string.IsNullOrWhiteSpace(AccessToken) || string.IsNullOrWhiteSpace(DataCentrePrefix))
            {
                Trace.TraceError(InvalidApiKeyMessage);
                throw new ArgumentException(InvalidApiKeyMessage);
            }

            var client = new RestClient(string.Format("https://{0}.api.mailchimp.com/{1}/", DataCentrePrefix, api));

            if (useOAuth)
            {
                client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(AccessToken);
            }

            client.AddHandler("application/json", new JsonSerializer());
            client.AddHandler("application/problem+json", new JsonSerializer());

            return client;
        }

        private async Task<TResult> ExecuteAsyncImpl<TResult>(IRestRequest request,
                                                              CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = CreateClient();

            var response = await _retryPolicyAsync.ExecuteAsync(async () =>
            {
                var result = await client.ExecuteTaskAsync<TResult>(request, cancellationToken);

                if (result == null)
                {
                    throw new NullReferenceException("Result from MailChimp call is null");
                }

                return result;
            });

            return response.Data;
        }

        private void ParseApiKey(string apiKey)
        {
            var strings = apiKey.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length != 2)
            {
                Trace.TraceError(InvalidApiKeyMessage);
                throw new ArgumentException(InvalidApiKeyMessage);
            }

            AccessToken = strings[0];
            DataCentrePrefix = strings[1];
        }
    }
}