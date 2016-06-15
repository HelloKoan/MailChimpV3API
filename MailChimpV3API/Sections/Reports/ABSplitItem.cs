using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class ABSplitItem
    {
        [JsonProperty("bounces")]
        public int Bounces { get; set; }

        [JsonProperty("abuse_reports")]
        public int AbuseReports { get; set; }

        [JsonProperty("unsubs")]
        public int Unsubscribes { get; set; }

        [JsonProperty("recipient_clicks")]
        public int RecipientClicks { get; set; }

        [JsonProperty("fowards")]
        public int Forwards { get; set; }

        [JsonProperty("fowards_opens")]
        public int ForwardsOpens { get; set; }

        [JsonProperty("opens")]
        public int Opens { get; set; }

        [JsonProperty("last_open")]
        public string LastOpen { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }
    }
}