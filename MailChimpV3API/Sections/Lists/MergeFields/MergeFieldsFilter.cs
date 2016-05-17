namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public class MergeFieldsFilter : MailChimpCollectionFilterBase
    {
        public override MailChimpCollectionFilterBase Clone()
        {
            return new MergeFieldsFilter
            {
                Count = Count,
                ExcludeFields = ExcludeFields,
                IncludeFields = IncludeFields,
                Offset = Offset
            };
        }
    }
}
