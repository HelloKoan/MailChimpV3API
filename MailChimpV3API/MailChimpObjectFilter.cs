using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API
{
    public class MailChimpFieldFilter
    {
        public MailChimpFieldFilter()
        {
            ExcludeFields = new List<string>();
            IncludeFields = new List<string>();
        }

        [JsonIgnore]
        public IEnumerable<string> IncludeFields { get; set; }

        [JsonIgnore]
        public IEnumerable<string> ExcludeFields { get; set; }

        /// <summary>
        ///     If not empty, determines the fields to exclude from the response.
        /// </summary>
        [JsonProperty("exclude_fields")]
        internal string ExcludeFieldsString
        {
            get { return ExcludeFields == null ? string.Empty : string.Join(",", ExcludeFields); }
        }

        /// <summary>
        ///     If not empty, determines the fields to include in the response.
        /// </summary>
        [JsonProperty("fields")]
        internal string IncludeFieldsString
        {
            get { return IncludeFields == null ? string.Empty : string.Join(",", IncludeFields); }
        }
    }
}
