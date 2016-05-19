using Newtonsoft.Json;

namespace MailChimpV3API.Batching
{
    public class BatchOperationResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("total_operations")]
        public int TotalOperations { get; set; }

        [JsonProperty("finished_operations")]
        public int FinishedOperations { get; set; }

        [JsonProperty("errored_operations")]
        public int ErroredOperations { get; set; }

        [JsonProperty("submitted_at")]
        public string SubmittedAt { get; set; }

        [JsonProperty("completed_at")]
        public string CompletedAt { get; set; }

        [JsonProperty("response_body_url")]
        public string ResponseBodyUrl { get; set; }
    }
}
