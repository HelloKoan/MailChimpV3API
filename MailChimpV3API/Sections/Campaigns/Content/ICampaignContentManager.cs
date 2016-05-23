using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Campaigns.Content
{
    public interface ICampaignContentManager
    {
        CampaignContent Get(string campaignId);

        Task<CampaignContent> GetAsync(string campaignId);
    }
}