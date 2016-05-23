using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API.Sections.Campaigns
{
    public class CampaignCollectionFilter : MailChimpCollectionFilterBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Types
        {
            [EnumMember(Value = "regular")]
            Regular,

            [EnumMember(Value = "plaintext")]
            PlainText,
            
            [EnumMember(Value = "absplit")]
            AbSplit,

            [EnumMember(Value = "rss")]
            Rss,

            [EnumMember(Value = "automation")]
            Automation,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Statuses
        {
            [EnumMember(Value = "save")]
            Save,

            [EnumMember(Value = "paused")]
            Paused,

            [EnumMember(Value = "schedule")]
            Schedule,

            [EnumMember(Value = "sending")]
            Sending,

            [EnumMember(Value = "sent")]
            Sent,
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortFields
        {
            [EnumMember(Value = "emails_sent")]
            EmailsSent,
            
            [EnumMember(Value = "send_time")]
            SendTime,

            [EnumMember(Value = "create_time")]
            CreateTime,
        }

        [JsonProperty("type")]
        public Types? Type { get; set; }

        [JsonProperty("status")]
        public Statuses? Status { get; set; }

        [JsonProperty("since_send_time")]
        public DateTime? SinceSendTime { get; set; }

        [JsonProperty("before_send_time")]
        public DateTime? BeforeSendTime { get; set; }

        [JsonProperty("since_create_time")]
        public DateTime? SinceCreateTime { get; set; }

        [JsonProperty("before_create_time")]
        public DateTime? BeforeCreateTime { get; set; }

        [JsonProperty("sort_field")]
        public SortFields SortField { get; set; }

        [JsonProperty("sort_dir")]
        public CollectionSortDirection SortDirection { get; set; }

        public override MailChimpCollectionFilterBase Clone()
        {
            return new CampaignCollectionFilter
            {
                Count = this.Count,
                Offset = this.Offset,
                ExcludeFields = this.ExcludeFields,
                IncludeFields = this.IncludeFields,
                Type = Type,
                Status = Status,
                SinceSendTime = SinceSendTime,
                SinceCreateTime = SinceCreateTime,
                BeforeCreateTime = BeforeCreateTime,
                BeforeSendTime = BeforeSendTime,
                SortField = SortField,
                SortDirection = SortDirection
            };
        }
    }
}
