using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public class MergeFieldsCollection : IMailChimpCollection
    {
        [JsonProperty("merge_fields")]
        public IEnumerable<MergeField> MergeFields { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
