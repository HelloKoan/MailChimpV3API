using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class ListMembersFilter : MailChimpCollectionFilterBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EmailTypes
        {
            [EnumMember(Value = "html")]
            Html,

            [EnumMember(Value = "text")]
            Text
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortFields
        {
            [EnumMember(Value = "timestamp_opt")]
            TimestampOpt,

            [EnumMember(Value = "last_changed")]
            LastChanged
        }

        /// <summary>
        /// Setting this value will restrict the collection to list members with the specified email type ('html' or 'text').
        /// </summary>
        [JsonProperty("email_type")]
        public EmailTypes? EmailType { get; set; }

        /// <summary>
        /// Setting this value will restrict the collection to list members with the given status.
        /// </summary>
        [JsonProperty("status")]
        public MailChimpListMember.Statuses? Status { get; set; }

        /// <summary>
        /// Setting this value will restrict the collection to list members that opted in since the specified date.
        /// </summary>
        [JsonProperty("since_timestamp_opt")]
        public DateTime? SinceTimestampOpt { get; set; }

        /// <summary>
        /// Setting this value will restrict the collection to list members that had their info last changed since the specified date.
        /// </summary>
        [JsonProperty("since_last_changed")]
        public DateTime? SinceLastChanged { get; set; }

        /// <summary>
        /// Setting this value will restrict the collection to list members that had their info last changed before the specified date.
        /// </summary>
        [JsonProperty("before_last_changed")]
        public DateTime? BeforeLastChanged { get; set; }

        /// <summary>
        /// Setting this value will restrict the collection to list members that opted in before the specified date.
        /// </summary>
        [JsonProperty("before_timestamp_opt")]
        public DateTime? BeforeTimestampOpt { get; set; }

        [JsonProperty("sort_field")]
        public SortFields? SortField { get; set; }

        [JsonProperty("sort_dir")]
        public CollectionSortDirection? SortDirection { get; set; }

        public override MailChimpCollectionFilterBase Clone()
        {
            return new ListMembersFilter
            {
                Count = Count,
                Offset = Offset,
                EmailType = EmailType,
                Status = Status,
                SinceTimestampOpt = SinceTimestampOpt,
                SinceLastChanged = SinceLastChanged,
                BeforeLastChanged = BeforeLastChanged,
                BeforeTimestampOpt = BeforeTimestampOpt,
                SortField = SortField,
                SortDirection = SortDirection,
            };
        }
    }
}