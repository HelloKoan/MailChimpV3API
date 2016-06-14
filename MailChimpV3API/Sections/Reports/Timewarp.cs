using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class Timewarp
    {
        [JsonProperty("gmt_offset")]
        public int GMTOffset { get; set; }

        [JsonProperty("opens")]
        public int Opens { get; set; }

        [JsonProperty("last_open")]
        public DateTime? LastOpen { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("clicks")]
        public int Clicks { get; set; }

        [JsonProperty("last_click")]
        public DateTime? LastClick { get; set; }

        [JsonProperty("unique_clicks")]
        public int UniqueClicks { get; set; }

        [JsonProperty("bounces")]
        public int Bounces { get; set; }
    }
}