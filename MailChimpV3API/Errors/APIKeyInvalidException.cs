namespace MailChimpV3API.Errors
{
    public class APIKeyInvalidException : MailChimpException
    {
        public APIKeyInvalidException(MailChimpApiProblem error) : base(error) { }
    }
}
