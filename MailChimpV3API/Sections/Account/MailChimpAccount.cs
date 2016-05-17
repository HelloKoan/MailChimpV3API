using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Account
{
    public class MailChimpAccount
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("total_subscribers")]
        public int TotalSubscribers { get; set; }

        [JsonProperty("pro_enabled")]
        public bool ProEnabled { get; set; }
    }
}
