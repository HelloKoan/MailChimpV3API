using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MailChimpV3API.Batching;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class ListMembersBatchBuilder : IListMembersBatchBuilder
    {
        /// <summary>
        /// Create a PATCH operation to update a member's data.
        /// </summary>
        public IEnumerable<BatchOperation> BuildUpdateOperations(string listId, IEnumerable<MailChimpListMember> members, CancellationToken cancellationToken = default(CancellationToken))
        {
            return members.Select(x => new BatchOperation
            {
                Method = "PATCH",
                Path = string.Format("/lists/{0}/members/{1}", listId, Hashing.MD5HashString(x.EmailAddress.ToLowerInvariant())),
                Body = Newtonsoft.Json.JsonConvert.SerializeObject(x)
            })
            .ToList();
        }
    }
}
