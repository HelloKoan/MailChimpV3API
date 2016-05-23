using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public class MergeFieldOptions
    {
        [JsonProperty("default_country")]
        public int DefaultCountry { get; set; }

        [JsonProperty("phone_format")]
        public string PhoneFormat { get; set; }

        [JsonProperty("date_format")]
        public string DateFormat { get; set; }

        [JsonProperty("choices")]
        public object[] Choices { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }
}
