using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class Forwards
    {
        [JsonProperty("opens_total")]
        public int OpensTotal { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("last_open")]
        public DateTime? LastOpen { get; set; }
    }
}