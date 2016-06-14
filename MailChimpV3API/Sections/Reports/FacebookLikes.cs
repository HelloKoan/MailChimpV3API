using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class FacebookLikes
    {
        [JsonProperty("recipient_likes")]
        public int RecipientLikes { get; set; }

        [JsonProperty("unique_likes")]
        public int UniqueLikes { get; set; }

        [JsonProperty("facebook_likes")]
        public int FBLikes { get; set; }
    }
}