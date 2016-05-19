using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API.Sections.Campaigns
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CreateCampaignType
    {
        [EnumMember(Value = "regular")]
        Regular,

        [EnumMember(Value = "plaintext")]
        PlainText,

        [EnumMember(Value = "absplit")]
        ABSplit,

        [EnumMember(Value = "rss")]
        RSS,

        [EnumMember(Value = "variate")]
        Variate,
    }

    public class CreateCampaignModel
    {
        [JsonProperty("type")]
        public CreateCampaignType Type { get; set; }

        [JsonProperty("recipients")]
        public CampaignRecipients Recipients { get; set; }

        [JsonProperty("settings")]
        public CampaignSettings Settings { get; set; }

        [JsonProperty("variate_settings")]
        public CreateCampaignVariateSettings VariateSettings { get; set; }

        [JsonProperty("tracking")]
        public CampaignTracking Tracking { get; set; }
    }

    public class CreateCampaignVariateSettings
    {
        [JsonProperty("winner_criteria")]
        public string WinnerCriteria { get; set; }

        [JsonProperty("wait_time")]
        public int WaitTime { get; set; }

        [JsonProperty("test_size")]
        public int TestSize { get; set; }

        [JsonProperty("subject_lines")]
        public IEnumerable<string> SubjectLines { get; set; }

        [JsonProperty("send_times")]
        public IEnumerable<DateTime> SendTimes { get; set; }

        [JsonProperty("from_names")]
        public IEnumerable<string> FromNames { get; set; }

        [JsonProperty("reply_to_address")]
        public IEnumerable<string> ReplyToAddress { get; set; }
    }
}
