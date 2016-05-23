using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API.Sections.Reports.EmailActivity
{
    public class EmailActivityReport
    {
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("email_id")]
        public string EmailId { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("activity")]
        public IEnumerable<EmailActivityReportActivity> Activity { get; set; }
    }

    public class EmailActivityReportActivity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActivityAction
        {
            [EnumMember(Value = "open")]
            Open,

            [EnumMember(Value = "click")]
            Click,

            [EnumMember(Value = "bounce")]
            Bounce
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum ActivityActionType
        {
            [EnumMember(Value = null)]
            None,
            [EnumMember(Value = "hard")]
            Hard,
            [EnumMember(Value = "soft")]
            Soft
        }

        [JsonProperty("action")]
        public ActivityAction Action { get; set; }

        [JsonProperty("type")]
        public ActivityActionType Type { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }
    }
}
