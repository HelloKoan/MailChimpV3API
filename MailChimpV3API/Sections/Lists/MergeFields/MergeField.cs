using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public class MergeField
    {
        [JsonProperty("merge_id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag (eg. FNAME).
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("default_value")]
        public string DefaultValue { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("display_order")]
        public int DisplayOrder { get; set; }

        [JsonProperty("options")]
        public MergeFieldOptions Options { get; set; }

        [JsonProperty("help_text")]
        public string HelpText { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }
    }
}
