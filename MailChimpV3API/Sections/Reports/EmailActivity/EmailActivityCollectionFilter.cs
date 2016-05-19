namespace MailChimpV3API.Sections.Reports.EmailActivity
{
    public class EmailActivityCollectionFilter : MailChimpCollectionFilterBase
    {
        public override MailChimpCollectionFilterBase Clone()
        {
            return new EmailActivityCollectionFilter()
            {
                Count = this.Count,
                Offset = this.Offset,
                ExcludeFields = this.ExcludeFields,
                IncludeFields = this.IncludeFields
            };
        }
    }
}
