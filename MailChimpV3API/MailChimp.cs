using MailChimpV3API.Sections.Campaigns;
using MailChimpV3API.Sections.Lists;
using MailChimpV3API.Sections.Reports;

namespace MailChimpV3API
{
    public class MailChimp : IMailChimp
    {
        public MailChimp(
            ICampaignManager campaignManager,
            IListManager listManager,
            IReportManager reportManager)
        {
            Campaigns = campaignManager;
            Lists = listManager;
            Reports = reportManager;
        }

        public ICampaignManager Campaigns { get; set; }
        public IListManager Lists { get; set; }
        public IReportManager Reports { get; set;}
    }
}
