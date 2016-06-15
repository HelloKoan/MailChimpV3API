using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class ListStats
    {
        [JsonProperty("sub_rate")]
        public long SubscribeRate { get; set; }

        [JsonProperty("unsub_rate")]
        public long UnsubscribeRate { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("click_rate")]
        public long ClickRate { get; set; }
    }
}