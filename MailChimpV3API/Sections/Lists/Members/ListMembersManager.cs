using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class ListMembersManager : IListMembersManager
    {
        private readonly IMailChimpConnector _connector;

        public ListMembersManager(IMailChimpConnector connector, IListMembersBatchBuilder batchBuilder)
        {
            BatchBuilder = batchBuilder;
            _connector = connector;
        }

        public IListMembersBatchBuilder BatchBuilder { get; private set; }

        public async Task<MailChimpListMembersCollection> GetManyAsync(string listId, ListMembersFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _connector.GetAsync<MailChimpListMembersCollection>(string.Format("lists/{0}/members", listId), cancellationToken: cancellationToken);
        }

        public Task<IEnumerable<MailChimpListMember>> GetAllAsync(
            string listId, 
            ListMembersFilter filter = null, 
            CancellationToken cancellationToken = default(CancellationToken),
            Func<int, int, Task> progressCallback = null)
        {
            filter = filter ?? new ListMembersFilter();

            return _connector.GetAllAsync<MailChimpListMember, MailChimpListMembersCollection>(string.Format("lists/{0}/members", listId),
                    filter,
                    collection => collection.Members,
                    cancellationToken,
                    progressCallback);
        }

        public async Task<IEnumerable<MailChimpListMember>> ExportAsync(
            string listId,
            DateTime? since = null,
            MailChimpListMember.Statuses status = MailChimpListMember.Statuses.Subscribed,
            TextWriter log = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (status == MailChimpListMember.Statuses.Pending)
            {
                throw new ArgumentException("Pending status is not supported by the export API");
            }

            log = log ?? TextWriter.Null;

            var queryStringParams = new Dictionary<string, string>
            {
                { "id", listId },
                { "status", status.ToString().ToLowerInvariant() }
            };

            if (since.HasValue)
            {
                queryStringParams.Add("since", since.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            var exportCustomers = await _connector.ExportAsync<MailChimpExportCustomer>("list",
                queryStringParams,
                true,
                log,
                cancellationToken);

            return exportCustomers.Select(e => new MailChimpListMember
            {
                EmailAddress = e.EmailAddress,
                ListId = listId,
                ConfirmTime = e.ConfirmTime,
                MergeFields = new MailChimpMergeFieldData
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName
                }
            });
        }

        public async Task<MailChimpListMember> GetSingleAsync(string listId, string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentException("Must provide an email address");
            }

            var emailMd5 = Hashing.MD5HashString(emailAddress.ToLowerInvariant());

            return await _connector.GetAsync<MailChimpListMember>(string.Format("lists/{0}/members/{1}", listId, emailMd5));
        }
    }
}