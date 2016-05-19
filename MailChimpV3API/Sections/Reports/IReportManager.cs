using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailChimpV3API.Sections.Reports.EmailActivity;

namespace MailChimpV3API.Sections.Reports
{
    public interface IReportManager
    {
        IEmailActivityManager EmailActivity { get; }

        Task<ReportCollection> GetManyAsync(ReportFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<Report>> GetAllAsync(ReportFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<Report> GetSingleAsync(string campaignId, MailChimpFieldFilter filter = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
