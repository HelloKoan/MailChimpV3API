using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailChimpV3API.Sections.Campaigns.Content;

namespace MailChimpV3API.Sections.Campaigns
{
    public class CampaignManager : ICampaignManager
    {
        private readonly IMailChimpConnector _connector;

        public CampaignManager(IMailChimpConnector connector)
        {
            _connector = connector;
            ContentManager = new CampaignContentManager(_connector);
        }

        public ICampaignContentManager ContentManager { get; set; }

        public async Task<IEnumerable<Campaign>> GetAllAsync(CampaignCollectionFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new CampaignCollectionFilter
            {
                Count = 1000
            };

            return await _connector.GetAllAsync<Campaign, CampaignCollection>(
                "campaigns",
                filter,
                collection => collection.Campaigns,
                cancellationToken);
        }

        public async Task<CampaignCollection> GetManyAsync(CampaignCollectionFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new CampaignCollectionFilter();

            return await _connector.GetAsync<CampaignCollection>("campaigns", filter, cancellationToken);
        }

        public async Task<Campaign> GetSingleAsync(string campaignId, MailChimpFieldFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _connector.GetAsync<Campaign>(string.Format("campaigns/{0}", campaignId), filter, cancellationToken);
        }

        public Campaign Create(CreateCampaignModel campaignModel)
        {
            return _connector.Post<Campaign>(
                "campaigns",
                body: campaignModel);
        }

        public async Task<Campaign> CreateAsync(CreateCampaignModel campaignModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await
                _connector.PostAsync<Campaign>(
                    "campaigns",
                    body: campaignModel,
                    cancellationToken: cancellationToken);
        }
    }
}
