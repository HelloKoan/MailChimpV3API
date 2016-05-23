namespace MailChimpV3API.Sections.Lists.MergeFields
{
    public static class MergeDataHelper
    {
        public static string ConvertDateFormat(string mailchimpFormat)
        {
            return mailchimpFormat.Replace('D', 'd').Replace('Y', 'y');
        }
    }
}
