using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Lists.Members
{
    public interface IListMembersManager
    {
        /// <summary>
        ///     Individuals who are currently or have, at one time, been subscribed to this list, includes members who have bounced
        ///     or unsubscribed.
        /// </summary>
        Task<MailChimpListMembersCollection> GetManyAsync(string listId, ListMembersFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Individuals who are currently or have, at one time, been subscribed to this list, includes members who have bounced
        ///     or unsubscribed.
        /// </summary>
        Task<IEnumerable<MailChimpListMember>> GetAllAsync(string listId, ListMembersFilter filter = null, CancellationToken cancellationToken = default(CancellationToken),
            Func<int, int, Task> progressCallback = null);

        /// <summary>
        ///     Individuals who are currently or have been previously suscribed to this list, including members who have bounced or
        ///     unsubscribed.
        /// </summary>
        Task<MailChimpListMember> GetSingleAsync(string listId, string emailAddress);

        /// <summary>
        ///  Individuals who are currently or have, at one time, been subscribed to this list, includes members who have bounced or unsubscribed. Using the export api.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <param name="since">Only return member whose data has changed since a GMT timestamp</param>
        /// <param name="status">The status to get members for - one of (subscribed, unsubscribed, cleaned), defaults to subscribed </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<MailChimpListMember>> ExportAsync(
            string listId,
            DateTime? since = null,
            MailChimpListMember.Statuses status = MailChimpListMember.Statuses.Subscribed,
            TextWriter log = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}