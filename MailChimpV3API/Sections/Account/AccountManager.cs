using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly IMailChimpConnector _connector;

        public AccountManager(IMailChimpConnector connector)
        {
            _connector = connector;
        }

        public MailChimpAccount GetAccount()
        {
            return _connector.Get<MailChimpAccount>("");
        }

        public async Task<MailChimpAccount> GetAccountAsync()
        {
            var account = await _connector.GetAsync<MailChimpAccount>("");
            return account;
        }
    }
}
