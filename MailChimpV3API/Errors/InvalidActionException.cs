namespace MailChimpV3API.Errors
{
    public class InvalidActionException : MailChimpException
    {
        public InvalidActionException(MailChimpApiProblem error) : base(error) { }
    }
}
