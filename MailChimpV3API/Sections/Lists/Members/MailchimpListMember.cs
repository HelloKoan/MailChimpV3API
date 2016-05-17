using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class MailChimpListMember
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Statuses
        {
            [EnumMember(Value = "subscribed")]
            Subscribed,

            [EnumMember(Value = "unsubscribed")]
            Unsubscribed,

            [EnumMember(Value = "cleaned")]
            Cleaned,

            [EnumMember(Value = "pending")]
            Pending
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("unique_email_id")]
        public string UniqueEmailId { get; set; }

        [JsonProperty("status")]
        public Statuses Status { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("CONFIRM_TIME")]
        public DateTime? ConfirmTime { get; set; }

        [JsonProperty("merge_fields")]
        public MailChimpMergeFieldData MergeFields { get; set; }
    }
}
