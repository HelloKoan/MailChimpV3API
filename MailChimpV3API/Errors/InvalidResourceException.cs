namespace MailChimpV3API.Errors
{
    public class InvalidResourceException : MailChimpException
    {
        public InvalidResourceException(MailChimpApiProblem error) : base(error) { }
    }
}
