using System;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class MailChimpExportCustomer
    {
        public string EmailAddress { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonProperty("CONFIRM_TIME")]
        public DateTime? ConfirmTime { get; set; }
    }
}