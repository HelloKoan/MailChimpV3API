using Newtonsoft.Json;

namespace MailChimpV3API.Errors
{
    public class MailChimpApiProblem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
