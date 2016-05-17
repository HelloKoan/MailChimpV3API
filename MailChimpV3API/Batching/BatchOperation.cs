using Newtonsoft.Json;

namespace MailChimpV3API.Batching
{
    public class BatchOperation
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("params")]
        public object Params { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("operation_id")]
        public string OperationId { get; set; }
    }
}
