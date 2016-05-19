using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API.Sections.Lists
{
    public class ListFilter : MailChimpCollectionFilterBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SortFields
        {
            [EnumMember(Value = "date_created")]
            DateCreated,

            [EnumMember(Value = "campaign_last_sent")]
            CampaignLastSent
        }

        public DateTime? SinceDateCreated { get; set; }

        public DateTime? BeforeDateCreated { get; set; }

        public DateTime? SinceCampaignLastSent { get; set; }

        public DateTime? BeforeCampaignLastSent { get; set; }

        public SortFields SortField { get; set; }

        public override MailChimpCollectionFilterBase Clone()
        {
            return new ListFilter
            {
                Count = Count,
                Offset = Offset,
                IncludeFields = IncludeFields,
                ExcludeFields = ExcludeFields,
                SortField = SortField,
                SinceCampaignLastSent = SinceCampaignLastSent,
                BeforeCampaignLastSent = BeforeCampaignLastSent,
                SinceDateCreated = SinceDateCreated,
                BeforeDateCreated = BeforeDateCreated
            };
        }
    }
}
