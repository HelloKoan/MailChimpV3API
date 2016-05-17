using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists
{
    public class MailChimpList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_created")]
        public string DateCreated { get; set; }

        [JsonProperty("permission_reminder")]
        public string PermissionReminder { get; set; }

        [JsonProperty("email_type_option")]
        public bool EmailTypeOption { get; set; }

        [JsonProperty("contact")]
        public ListContact Contact { get; set; }

        [JsonProperty("campaign_defaults")]
        public ListCampignDefaults CampaignDefaults { get; set; }

        [JsonProperty("list_rating")]
        public int ListRating { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("stats")]
        public ListStats Stats { get; set; }
    }

    public class ListContact
    {
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string CountryCode { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }
    }

    public class ListCampignDefaults
    {
        [JsonProperty("from_name")]
        public string FromName { get; set; }

        [JsonProperty("from_email")]
        public string FromEmail { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class ListStats
    {
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("unsubscribe_count")]
        public int UnsubscribeCount { get; set; }

        [JsonProperty("cleaned_count")]
        public int CleanedCount { get; set; }

        [JsonProperty("member_count_since_send")]
        public int MemberCountSinceSend { get; set; }

        [JsonProperty("unsubscribe_count_since_send")]
        public int UnsubscribeCountSinceSend { get; set; }

        [JsonProperty("cleaned_count_since_send")]
        public int CleanedCountSinceSend { get; set; }

        [JsonProperty("campaign_count")]
        public int CampaignCount { get; set; }

        [JsonProperty("campaign_last_sent")]
        public string CampaignLastSend { get; set; }

        [JsonProperty("merge_field_count")]
        public int MergeFieldCount { get; set; }

        [JsonProperty("avg_sub_rate")]
        public double AverageSubscriptionRate { get; set; }

        [JsonProperty("avg_unsub_rate")]
        public double AverageUnsubscribeRate { get; set; }

        [JsonProperty("target_sub_rate")]
        public double TargetSubscribeRate { get; set; }

        [JsonProperty("open_rate")]
        public double OpenRate { get; set; }

        [JsonProperty("click_rate")]
        public double ClickRate { get; set; }

        [JsonProperty("last_sub_date")]
        public string LastSubscriptionDate { get; set; }

        [JsonProperty("last_unsub_date")]
        public string LastUnsubscribeDate { get; set; }
    }
}
