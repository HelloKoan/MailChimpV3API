using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class ReportCollection : IMailChimpCollection
    {
        [JsonProperty("reports")]
        public List<Report> Reports { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
