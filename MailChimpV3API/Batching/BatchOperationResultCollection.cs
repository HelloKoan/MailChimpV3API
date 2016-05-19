using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Batching
{
    public class BatchOperationResultCollection : IMailChimpCollection
    {
        [JsonProperty("batches")]
        public IEnumerable<BatchOperationResponse> Batches { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
