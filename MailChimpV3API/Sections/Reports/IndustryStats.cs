using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class IndustryStats
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("click_rate")]
        public long ClickRate { get; set; }

        [JsonProperty("bounce_rate")]
        public long BounceRate { get; set; }

        [JsonProperty("unopen_rate")]
        public long UnopenRate { get; set; }

        [JsonProperty("unsub_rate")]
        public long UnsubRate { get; set; }

        [JsonProperty("abuste_rate")]
        public long AbuseRate { get; set; }
    }
}