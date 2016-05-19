using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class MailChimpMergeFieldData
    {
        [JsonProperty("FNAME")]
        public string FirstName { get; set; }

        [JsonProperty("LNAME")]
        public string LastName { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JToken> MergeFields { get; set; }
    }
}