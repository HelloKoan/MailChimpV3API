using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Campaigns
{
    public interface ICampaignManager
    {
        Task<CampaignCollection> GetManyAsync(
            CampaignCollectionFilter filter = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Campaign> GetSingleAsync(string campaignId, MailChimpFieldFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
