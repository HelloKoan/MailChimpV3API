namespace MailChimpV3API.Errors
{
    public class JSONParseErrorException : MailChimpException
    {
        public JSONParseErrorException(MailChimpApiProblem error) : base(error) { }
    }
}
