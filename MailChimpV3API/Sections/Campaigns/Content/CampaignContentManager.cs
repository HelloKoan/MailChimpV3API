using System;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Campaigns.Content
{
    public class CampaignContentManager : ICampaignContentManager
    {
        private readonly IMailChimpConnector _connector;

        public CampaignContentManager(IMailChimpConnector connector)
        {
            _connector = connector;
        }

        public async Task<CampaignContent> GetAsync(string campaignId)
        {
            return await _connector.GetAsync<CampaignContent>(string.Format("campaigns/{0}/content"));
        }

        public CampaignContent Get(string campaignId)
        {
            return _connector.Get<CampaignContent>(string.Format("campaigns/{0}/content"));
        }
    }
}
