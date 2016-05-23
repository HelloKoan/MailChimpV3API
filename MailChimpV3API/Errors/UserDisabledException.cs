namespace MailChimpV3API.Errors
{
    public class UserDisabledException : MailChimpException
    {
        public UserDisabledException(MailChimpApiProblem error) : base(error) { }
    }
}
