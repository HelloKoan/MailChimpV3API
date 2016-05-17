namespace MailChimpV3API.Errors
{
    public class APIKeyMissingException : MailChimpException
    {
        public APIKeyMissingException(MailChimpApiProblem error) : base(error) { }
    }
}
