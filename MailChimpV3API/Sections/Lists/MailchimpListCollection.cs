using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists
{
    public class MailChimpListCollection : IMailChimpCollection
    {
        [JsonProperty("lists")]
        public IEnumerable<MailChimpList> Lists { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}