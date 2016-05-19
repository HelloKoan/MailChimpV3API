namespace MailChimpV3API.Errors
{
    public class ResourceNotFoundException : MailChimpException
    {
        public ResourceNotFoundException(MailChimpApiProblem error) : base(error) { }
    }
}
