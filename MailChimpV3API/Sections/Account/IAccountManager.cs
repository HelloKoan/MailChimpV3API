using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Account
{
    public interface IAccountManager
    {
        MailChimpAccount GetAccount();

        Task<MailChimpAccount> GetAccountAsync();
    }
}