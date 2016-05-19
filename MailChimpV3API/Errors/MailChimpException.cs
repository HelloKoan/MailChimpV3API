using System;

namespace MailChimpV3API.Errors
{
    public class MailChimpException : Exception
    {
        public MailChimpException(MailChimpApiProblem apiProblem)
            : base(apiProblem.Detail)
        {
            Title = apiProblem.Title;
            Status = apiProblem.Status;
            Type = apiProblem.Type;
        }

        public string Title { get; private set; }
        public int Status { get; private set; }
        public string Type { get; private set; }
    }
}
