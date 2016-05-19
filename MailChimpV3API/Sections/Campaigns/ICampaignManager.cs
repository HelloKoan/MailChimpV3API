using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Campaigns
{
    public interface ICampaignManager
    {
        Task<IEnumerable<Campaign>> GetAllAsync(CampaignCollectionFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<CampaignCollection> GetManyAsync(
            CampaignCollectionFilter filter = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Campaign> GetSingleAsync(string campaignId, MailChimpFieldFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<Campaign> CreateAsync(CreateCampaignModel campaignModel, CancellationToken cancellationToken = default(CancellationToken));

        Campaign Create(CreateCampaignModel campaignModel);
    }
}
