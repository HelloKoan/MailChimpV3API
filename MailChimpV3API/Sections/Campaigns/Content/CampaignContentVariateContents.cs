using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Campaigns.Content
{
    public class CampaignContentVariateContents
    {
        [JsonProperty("content_label")]
        public string ContentLabel { get; set; }

        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
