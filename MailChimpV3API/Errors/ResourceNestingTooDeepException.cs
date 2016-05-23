namespace MailChimpV3API.Errors
{
    public class ResourceNestingTooDeepException : MailChimpException
    {
        public ResourceNestingTooDeepException(MailChimpApiProblem error) : base(error) { }
    }
}
