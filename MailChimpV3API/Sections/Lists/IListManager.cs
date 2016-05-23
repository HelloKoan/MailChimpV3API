using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailChimpV3API.Sections.Lists.Members;
using MailChimpV3API.Sections.Lists.MergeFields;

namespace MailChimpV3API.Sections.Lists
{
    public interface IListManager
    {
        IListMembersManager Members { get; }

        IMergeFieldManager MergeFields { get; set; }

        /// <summary>
        ///     Deletes a specific list.
        /// </summary>
        Task DeleteListAsync(string listId);

        /// <summary>
        ///     Gets all lists.
        /// </summary>
        Task<IEnumerable<MailChimpList>> GetAllAsync(ListFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Gets many lists.
        /// </summary>
        Task<MailChimpListCollection> GetManyAsync(ListFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Gets information about a list.
        /// </summary>
        Task<MailChimpList> GetSingleAsync(string listId);

        /// <summary>
        ///     Updates a specific list.
        /// </summary>
        Task UpdateListAsync(MailChimpList list);
    }
}