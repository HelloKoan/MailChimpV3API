using MailChimpV3API.Sections.Account;
using MailChimpV3API.Sections.Campaigns;
using MailChimpV3API.Sections.Lists;
using MailChimpV3API.Sections.Lists.Members;
using MailChimpV3API.Sections.Reports;
using MailChimpV3API.Sections.Reports.EmailActivity;

namespace MailChimpV3API
{
    public class MailChimpFactory : IMailChimpFactory
    {
        public IMailChimp Create(string apiKey)
        {
            var mailchimpConnector = new MailChimpConnector(apiKey);
            return Create(mailchimpConnector);
        }

        public IMailChimp Create(string accessToken, string dataCentrePrefix)
        {
            var mailchimpConnector = new MailChimpConnector(accessToken, dataCentrePrefix);
            return Create(mailchimpConnector);
        }

        public IMailChimp Create(IMailChimpConnector connector)
        {
            return new MailChimp(
                new AccountManager(connector), 
                new CampaignManager(connector),
                new ListManager(connector, new ListMembersManager(connector)),
                new ReportManager(connector, new EmailActivityManager(connector)));
        }
    }
}
