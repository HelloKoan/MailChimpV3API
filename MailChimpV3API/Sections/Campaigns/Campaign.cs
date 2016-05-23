using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Campaigns
{
    public class Campaign
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        [JsonProperty("archive_url")]
        public string ArchiveUrl { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("emails_sent")]
        public int EmailSent { get; set; }

        [JsonProperty("send_time")]
        public string SendTime { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("recipients")]
        public CampaignRecipients Recipients { get; set; }

        [JsonProperty("settings")]
        public CampaignSettings Settings { get; set; }

        [JsonProperty("tracking")]
        public CampaignTracking Tracking { get; set; }

        [JsonProperty("ab_split_opts")]
        public CampaignABSplitOptions ABSplitOptions { get; set; }

        [JsonProperty("report_summary")]
        public CampaignReportSummary ReportSummary { get; set; }

        [JsonProperty("delivery_status")]
        public CampaignDeliveryStatus DeliveryStatus { get; set; }
    }

    public class CampaignSettings
    {
        [JsonProperty("subject_line")]
        public string SubjectLine { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("from_name")]
        public string FromName { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonProperty("use_conversation")]
        public bool UseConversation { get; set; }

        [JsonProperty("to_name")]
        public string ToName { get; set; }

        [JsonProperty("folder_id")]
        public string FolderId { get; set; }

        [JsonProperty("authenticate")]
        public bool Authenticate { get; set; }

        [JsonProperty("auto_footer")]
        public bool AutoFooter { get; set; }

        [JsonProperty("inline_css")]
        public bool InlineCSS { get; set; }

        [JsonProperty("auto_tweet")]
        public bool AutoTweet { get; set; }

        [JsonProperty("auto_fb_post")]
        public string[] AutoFBPost { get; set; }

        [JsonProperty("fb_comments")]
        public bool FBComments { get; set; }

        [JsonProperty("timewarp")]
        public bool Timewarp { get; set; }

        [JsonProperty("drap_and_drop")]
        public bool DragAndDrop { get; set; }
    }

    public class CampaignTracking
    {
        [JsonProperty("opens")]
        public bool Opens { get; set; }

        [JsonProperty("html_clicks")]
        public bool HTMLClick { get; set; }

        [JsonProperty("text_clicks")]
        public bool TextClicks { get; set; }

        [JsonProperty("goal_tracking")]
        public bool GoalTracking { get; set; }

        [JsonProperty("ecomm360")]
        public bool EComm360 { get; set; }

        [JsonProperty("google_analytics")]
        public string GoogleAnalytics { get; set; }

        [JsonProperty("salesforce")]
        public OtherCampaignTracking SalesForce { get; set; }

        [JsonProperty("highrise")]
        public OtherCampaignTracking HighRise { get; set; }

        [JsonProperty("capsule")]
        public NoteTracking Capsule { get; set; }
    }

    public class NoteTracking
    {
        [JsonProperty("notes")]
        public bool Notes { get; set; }
    }

    public class OtherCampaignTracking : NoteTracking
    {
        [JsonProperty("campaign")]
        public bool Campaign { get; set; }
    }

    public class CampaignRecipients
    {
        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("segment_text")]
        public string SegmentText { get; set; }
    }

    public class CampaignABSplitOptions
    {
        [JsonProperty("split_test")]
        public string SplitTest { get; set; }

        [JsonProperty("pick_winner")]
        public string PickWinner { get; set; }

        [JsonProperty("wait_units")]
        public string WaitUnits { get; set; }

        [JsonProperty("wait_time")]
        public int WaitTime { get; set; }

        [JsonProperty("split_size")]
        public int SplitSize { get; set; }

        [JsonProperty("from_name_a")]
        public string FromNameA { get; set; }

        [JsonProperty("from_name_b")]
        public string FromNameB { get; set; }

        [JsonProperty("reply_name_a")]
        public string ReplyNameA { get; set; }

        [JsonProperty("reply_name_b")]
        public string ReplyNameB { get; set; }

        [JsonProperty("subject_a")]
        public string SubjectA { get; set; }

        [JsonProperty("subject_b")]
        public string SubjectB { get; set; }

        [JsonProperty("send_time_a")]
        public string SendTimeA { get; set; }

        [JsonProperty("send_time_b")]
        public string SendTimeB { get; set; }

        [JsonProperty("send_time_winner")]
        public string SendTimeWinner { get; set; }
    }

    public class CampaignReportSummary
    {
        [JsonProperty("opens")]
        public int AutomationOpens { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("open_rate")]
        public double OpenRate { get; set; }

        [JsonProperty("clicks")]
        public int TotalClicks { get; set; }

        [JsonProperty("subscriber_clicks")]
        public int UniqueSubscriberClicks { get; set; }

        [JsonProperty("click_rate")]
        public double ClickRate { get; set; }
    }

    public class CampaignDeliveryStatus
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("can_cancel")]
        public bool CanCancel { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("emails_sent")]
        public int EmailsSent { get; set; }
    }
}
