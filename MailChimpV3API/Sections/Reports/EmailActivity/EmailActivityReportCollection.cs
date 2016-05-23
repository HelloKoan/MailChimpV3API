using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports.EmailActivity
{
    public class EmailActivityReportCollection : IMailChimpCollection
    {
        [JsonProperty("emails")]
        public IEnumerable<EmailActivityReport> Emails { get; set; }

        [JsonProperty("campaignId")]
        public string CampaignId { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
