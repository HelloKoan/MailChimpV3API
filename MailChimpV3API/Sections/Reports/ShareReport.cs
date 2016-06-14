using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class ShareReport
    {
        [JsonProperty("share_url")]
        public string ShareURL { get; set; }

        [JsonProperty("share_password")]
        public string SharePassword { get; set; }
    }
}