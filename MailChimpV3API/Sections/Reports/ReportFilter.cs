namespace MailChimpV3API.Sections.Reports
{
    public class ReportFilter : MailChimpCollectionFilterBase
    {
        public override MailChimpCollectionFilterBase Clone()
        {
            return new ReportFilter
            {
                Count = this.Count,
                Offset = this.Offset,
                IncludeFields = this.IncludeFields,
                ExcludeFields = this.ExcludeFields
            };
        }
    }
}
