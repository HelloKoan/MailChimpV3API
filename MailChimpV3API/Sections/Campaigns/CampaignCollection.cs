using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Campaigns
{
    public class CampaignCollection : IMailChimpCollection
    {
        [JsonProperty("campaigns")]
        public IEnumerable<Campaign> Campaigns { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
