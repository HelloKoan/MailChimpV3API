using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MailChimpV3API.Sections.Reports.EmailActivity;

namespace MailChimpV3API.Sections.Reports
{
    public class ReportManager : IReportManager
    {
        private readonly IMailChimpConnector _connector;

        public ReportManager(IMailChimpConnector connector, IEmailActivityManager emailActivityManager)
        {
            _connector = connector;
            EmailActivity = emailActivityManager;
        }

        public IEmailActivityManager EmailActivity
        {
            get;
            private set;
        }

        public async Task<ReportCollection> GetManyAsync(ReportFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _connector.GetAsync<ReportCollection>("reports", filter, cancellationToken);
        }

        public async Task<Report> GetSingleAsync(string campaignId, MailChimpFieldFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _connector.GetAsync<Report>(string.Format("reports/{0}", campaignId), filter, cancellationToken);
        }

        public async Task<IEnumerable<Report>> GetAllAsync(ReportFilter filter = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            filter = filter ?? new ReportFilter
            {
                Count = 1000
            };

            return await _connector.GetAllAsync<Report, ReportCollection>(
                "reports",
                filter,
                collection => collection.Reports,
                cancellationToken);
        }
    }
}
