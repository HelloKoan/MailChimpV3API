using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailChimpV3API.Sections.Lists.Members;

namespace MailChimpV3API.Sections.Lists
{
    public class ListManager : IListManager
    {
        private readonly IMailChimpConnector _connector;

        public ListManager(IMailChimpConnector connector, IListMembersManager listMembersManager)
        {
            _connector = connector;
            Members = listMembersManager;
        }

        public IListMembersManager Members { get; private set; }

        public async Task DeleteListAsync(string listId)
        {
            await _connector.DeleteAsync<MailChimpList>(listId);
        }

        public Task<MailChimpListCollection> GetManyAsync(ListFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new ListFilter();

            return _connector.GetAsync<MailChimpListCollection>("lists", filter, cancellationToken);
        }

        public Task<IEnumerable<MailChimpList>> GetAllAsync(ListFilter filter = null,
                                                            CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new ListFilter();
            
            return _connector.GetAllAsync<MailChimpList, MailChimpListCollection>(
                "lists",
                filter,
                collection => collection.Lists,
                cancellationToken);
        }

        public async Task<MailChimpList> GetSingleAsync(string listId)
        {
            return await _connector.GetAsync<MailChimpList>(string.Format("lists/{0}", listId));
        }

        public async Task UpdateListAsync(MailChimpList list)
        {
            await _connector.PatchAsync<MailChimpList>(string.Format("lists/{0}", list.Id), null, list);
        }
    }
}
