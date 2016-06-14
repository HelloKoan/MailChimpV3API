using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class Bounces
    {
        [JsonProperty("hard_bounces")]
        public int HardBounces { get; set; }

        [JsonProperty("soft_bounces")]
        public int SoftBounces { get; set; }

        [JsonProperty("syntax_errors")]
        public int SyntaxErrors { get; set; }
    }
}