using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Campaigns.Content
{
    public class CampaignContent
    {
        [JsonProperty("variate_contents")]
        public CampaignContentVariateContents VariateContents { get; set; }

        [JsonProperty("plain_text")]
        public string PlainText { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
