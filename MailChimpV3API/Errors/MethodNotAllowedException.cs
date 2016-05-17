namespace MailChimpV3API.Errors
{
    public class MethodNotAllowedException : MailChimpException
    {
        public MethodNotAllowedException(MailChimpApiProblem error) : base(error) { }
    }
}
