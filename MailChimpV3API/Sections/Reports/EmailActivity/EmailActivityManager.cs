using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MailChimpV3API.Sections.Reports.EmailActivity
{
    public class EmailActivityManager : IEmailActivityManager
    {
        private readonly IMailChimpConnector _connector;

        public EmailActivityManager(IMailChimpConnector connector)
        {
            _connector = connector;
        }

        public async Task<EmailActivityReportCollection> GetManyAsync(string campaignId, EmailActivityCollectionFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new EmailActivityCollectionFilter();

            return await _connector.GetAsync<EmailActivityReportCollection>(string.Format("reports/{0}/email-activity", campaignId), filter, cancellationToken);
        }

        public async Task<IEnumerable<EmailActivityReport>> GetAllAsync(string campaignId, EmailActivityCollectionFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new EmailActivityCollectionFilter
            {
                Count = 1000
            };

            return await _connector.GetAllAsync<EmailActivityReport, EmailActivityReportCollection>(
                string.Format("reports/{0}/email-activity", campaignId),
                filter,
                collection => collection.Emails,
                cancellationToken);
        }

        public async Task<EmailActivityReport> GetSingleAsync(string campaignId, string emailId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _connector.GetAsync<EmailActivityReport>(string.Format("reports/{0}/email-activity/{1}", campaignId, emailId), null, cancellationToken);
        }

        public async Task<IEnumerable<EmailActivityReport>> ExportAsync(
            string campaignId, 
            DateTime? since = null, 
            bool includeEmpty = false, 
            TextWriter log = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            log = log ?? TextWriter.Null;

            var queryStringParams = new Dictionary<string, string>
            {
                { "id", campaignId },
                { "include_empty", includeEmpty.ToString().ToLowerInvariant() }
            };

            if (since.HasValue)
            {
                queryStringParams.Add("since", since.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            log.WriteLine("Sending request to MailChimp: " + JsonConvert.SerializeObject(queryStringParams));

            var exportActivity = await _connector.ExportAsync<JObject>(
                "campaignSubscriberActivity", 
                queryStringParams, 
                false, 
                log,
                cancellationToken);
            
            log.WriteLine("Request returned from MailChimp, building EmailActivityReports");

            return exportActivity.Select(e =>
            {
                if (e == null)
                {
                    return null;
                }

                var property = e.First as JProperty;
                if (property == null)
                {
                    return null;
                }

                var email = property.Name;

                var actions = property.Value as JArray;

                if (actions == null)
                {
                    return null;
                }

                return new EmailActivityReport
                {
                    Activity = actions.Select(x =>
                    {
                        var activityAction = (EmailActivityReportActivity.ActivityAction)
                                                        Enum.Parse(typeof(EmailActivityReportActivity.ActivityAction), x["action"].Value<string>(), true);

                        return new EmailActivityReportActivity
                        {
                            Action =
                                activityAction,
                            TimeStamp = DateTime.Parse(x["timestamp"].Value<string>()),
                            URL = x["url"].HasValues ? x["url"].Value<string>() : null
                        };
                    }).ToList(),
                    CampaignId = campaignId,
                    EmailAddress = email
                };
            }).Where(x => x != null);
        }
    }

    public class ExportCampaignActivity
    {
        
    }
}
