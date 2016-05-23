namespace MailChimpV3API.Errors
{
    public class WrongDataCentreException : MailChimpException
    {
        public WrongDataCentreException(MailChimpApiProblem error) : base(error) { }
    }
}
