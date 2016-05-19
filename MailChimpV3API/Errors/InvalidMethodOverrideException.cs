namespace MailChimpV3API.Errors
{
    public class InvalidMethodOverrideException : MailChimpException
    {
        public InvalidMethodOverrideException(MailChimpApiProblem error) : base(error) { }
    }
}
