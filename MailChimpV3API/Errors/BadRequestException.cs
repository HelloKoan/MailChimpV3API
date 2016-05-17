namespace MailChimpV3API.Errors
{
    public class BadRequestException : MailChimpException
    {
        public BadRequestException(MailChimpApiProblem apiProblem) : base(apiProblem) { }
    }
}
