using MailChimpV3API.Batching;
using MailChimpV3API.Sections.Account;
using MailChimpV3API.Sections.Campaigns;
using MailChimpV3API.Sections.Lists;
using MailChimpV3API.Sections.Reports;

namespace MailChimpV3API
{
    public class MailChimp : IMailChimp
    {
        public MailChimp(
            IAccountManager accountManager,
            IBatchManager batchManager,
            ICampaignManager campaignManager,
            IListManager listManager,
            IReportManager reportManager)
        {
            Account = accountManager;
            Batching = batchManager;
            Campaigns = campaignManager;
            Lists = listManager;
            Reports = reportManager;
        }

        public IAccountManager Account { get; set; }

        public IBatchManager Batching { get; set; }

        public ICampaignManager Campaigns { get; set; }

        public IListManager Lists { get; set; }

        public IReportManager Reports { get; set; }
    }
}