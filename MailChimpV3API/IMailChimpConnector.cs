using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace MailChimpV3API
{
    public interface IMailChimpConnector
    {
        TResult Delete<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) 
            where TResult : new();

        Task<TResult> DeleteAsync<TResult>(string action,
                                           Dictionary<string, string> queryStringParams = null,
                                           object body = null,
                                           CancellationToken cancellationToken = default(CancellationToken)) 
            where TResult : new();

        Task<IEnumerable<TResult>> GetAllAsync<TResult, TCollection>(string action,
                                                                     MailChimpCollectionFilterBase filter,
                                                                     Func<TCollection, IEnumerable<TResult>> transformResult,
                                                                     CancellationToken cancellationToken = default(CancellationToken),
                                                                     Func<int, int, Task> progressCallback = null)
            where TCollection : class, IMailChimpCollection, new();

        Task<IEnumerable<TResult>> ExportAsync<TResult>(
            string action, 
            Dictionary<string, string> queryStringParams, 
            bool hasHeader = false, 
            TextWriter log = null,
            CancellationToken cancellationToken = default(CancellationToken));

        TResult Execute<TResult>(string action, Dictionary<string, string> queryStringParams, object body, Method method) 
            where TResult : new();

        Task<TResult> ExecuteAsync<TResult>(string action,
                                            MailChimpFieldFilter filter = null,
                                            CancellationToken cancellationToken = default(CancellationToken)) 
            where TResult : new();

        TResult Get<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) 
            where TResult : new();

        Task<TResult> GetAsync<TResult>(string action,
                                        MailChimpFieldFilter filter = null,
                                        CancellationToken cancellationToken = default(CancellationToken)) 
            where TResult : new();

        TResult Patch<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) 
            where TResult : new();

        Task<TResult> PatchAsync<TResult>(string action,
                                          Dictionary<string, string> queryStringParams = null,
                                          object body = null,
                                          CancellationToken cancellationToken = default(CancellationToken)) 
            where TResult : new();

        TResult Post<TResult>(string action, Dictionary<string, string> queryStringParams = null, object body = null) 
            where TResult : new();

        Task<TResult> PostAsync<TResult>(string action,
                                         Dictionary<string, string> queryStringParams = null,
                                         object body = null,
                                         CancellationToken cancellationToken = default(CancellationToken)) 
            where TResult : new();
    }
}