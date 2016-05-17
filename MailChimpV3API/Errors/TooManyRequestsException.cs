namespace MailChimpV3API.Errors
{
    public class TooManyRequestsException : MailChimpException
    {
        public TooManyRequestsException(MailChimpApiProblem error) : base(error) { }
    }
}
