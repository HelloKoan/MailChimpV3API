using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class TimeSeries
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("emails_sent")]
        public int EmailsSent { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("recipients_clicks")]
        public int RecipientsClicks { get; set; }
    }
}