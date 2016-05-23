namespace MailChimpV3API.Errors
{
    public class ForbiddenException : MailChimpException
    {
        public ForbiddenException(MailChimpApiProblem error) : base(error) { }
    }
}
