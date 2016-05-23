using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MailChimpV3API.Sections.Reports.EmailActivity
{
    public interface IEmailActivityManager
    {
        Task<IEnumerable<EmailActivityReport>> GetAllAsync(string campaignId, EmailActivityCollectionFilter filter = null,
                                                           CancellationToken cancellationToken = default(CancellationToken));

        Task<EmailActivityReportCollection> GetManyAsync(string campaignId, EmailActivityCollectionFilter filter = null,
                                                         CancellationToken cancellationToken = default(CancellationToken));

        Task<EmailActivityReport> GetSingleAsync(string campaignId, string emailId, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<EmailActivityReport>> ExportAsync(
            string campaignId,
            DateTime? since = null,
            bool includeEmpty = false,
            TextWriter log = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}