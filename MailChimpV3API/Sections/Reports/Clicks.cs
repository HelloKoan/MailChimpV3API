using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class Clicks
    {
        [JsonProperty("clicks_total")]
        public int ClicksTotal { get; set; }

        [JsonProperty("unique_clicks")]
        public int UniqueClicks { get; set; }

        [JsonProperty("unique_subscriber_clicks")]
        public int UniqueSubscriberClicks { get; set; }

        [JsonProperty("click_rate")]
        public long ClickRate { get; set; }

        [JsonProperty("last_click")]
        public DateTime? LastClick { get; set; }
    }
}