using MailChimpV3API.Sections.Campaigns;
using MailChimpV3API.Sections.Lists;
using MailChimpV3API.Sections.Reports;

namespace MailChimpV3API
{
    public interface IMailChimp
    {
        ICampaignManager Campaigns { get; set; }

        IListManager Lists { get; set; }

        IReportManager Reports { get; set; }
    }
}
