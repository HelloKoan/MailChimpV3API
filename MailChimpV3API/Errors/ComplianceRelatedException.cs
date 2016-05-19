namespace MailChimpV3API.Errors
{
    public class ComplianceRelatedException : MailChimpException
    {
        public ComplianceRelatedException(MailChimpApiProblem error) : base(error) { }
    }
}
