using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class Opens
    {
        [JsonProperty("total_opens")]
        public int TotalOpens { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("last_open")]
        public DateTime? LastOpen { get; set; }
    }
}