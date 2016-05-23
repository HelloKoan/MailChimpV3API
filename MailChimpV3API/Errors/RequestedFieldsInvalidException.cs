namespace MailChimpV3API.Errors
{
    public class RequestedFieldsInvalidException : MailChimpException
    {
        public RequestedFieldsInvalidException(MailChimpApiProblem error) : base(error) { }
    }
}
