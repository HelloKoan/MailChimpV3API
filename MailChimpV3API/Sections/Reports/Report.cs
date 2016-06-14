using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Reports
{
    public class Report
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("campaign_title")]
        public string CampaignTitle { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("emails_sent")]
        public int EmailsSent { get; set; }

        [JsonProperty("abuse_reports")]
        public int AbuseReports { get; set; }

        [JsonProperty("unsubscribed")]
        public int Unsubscribed { get; set; }

        [JsonProperty("send_time")]
        public DateTime? SendTime { get; set; }

        [JsonProperty("bounces")]
        public Bounces Bounces { get; set; }

        [JsonProperty("forwards")]
        public Forwards Forwards { get; set; }

        [JsonProperty("opens")]
        public Opens Opens { get; set; }

        [JsonProperty("clicks")]
        public Clicks Clicks { get; set; }

        [JsonProperty("facebook_likes")]
        public FacebookLikes FacebookLikes { get; set; }

        [JsonProperty("industry_stats")]
        public IndustryStats IndustryStats { get; set; }

        [JsonProperty("list_stats")]
        public ListStats ListStats { get; set; }

        [JsonProperty("ab_split")]
        public ABSplit ABSplit { get; set; }

        [JsonProperty("timewarp")]
        public List<Timewarp> Timewarp { get; set; }

        [JsonProperty("timeseries")]
        public List<TimeSeries> Timeseries { get; set; }

        [JsonProperty("share_report")]
        public ShareReport ShareReport { get; set; }
    }
}