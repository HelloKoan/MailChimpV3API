using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class ABSplit
    {
        [JsonProperty("a")]
        public ABSplitItem A { get; set; }

        [JsonProperty("b")]
        public ABSplitItem B { get; set; }
    }
}