using System.Collections.Generic;
using System.Threading;
using MailChimpV3API.Batching;

namespace MailChimpV3API.Sections.Lists.Members
{
    public interface IListMembersBatchBuilder
    {
        IEnumerable<BatchOperation> BuildUpdateOperations(string listId, IEnumerable<MailChimpListMember> members, CancellationToken cancellationToken = default(CancellationToken));
    }
}