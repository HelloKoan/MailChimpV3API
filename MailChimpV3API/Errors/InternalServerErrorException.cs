namespace MailChimpV3API.Errors
{
    public class InternalServerErrorException : MailChimpException
    {
        public InternalServerErrorException(MailChimpApiProblem error) : base(error) { }
    }
}
