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
        public string SendTime { get; set; }

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

    public class Bounces
    {
        [JsonProperty("hard_bounces")]
        public int HardBounces { get; set; }

        [JsonProperty("soft_bounces")]
        public int SoftBounces { get; set; }

        [JsonProperty("syntax_errors")]
        public int SyntaxErrors { get; set; }
    }

    public class Forwards
    {
        [JsonProperty("opens_total")]
        public int OpensTotal { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("last_open")]
        public string LastOpen { get; set; }
    }

    public class Opens
    {
        [JsonProperty("total_opens")]
        public int TotalOpens { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("last_open")]
        public string LastOpen { get; set; }
    }

    public class Clicks
    {
        [JsonProperty("clicks_total")]
        public int ClicksTotal { get; set; }

        [JsonProperty("unique_clicks")]
        public int UniqueClicks { get; set; }

        [JsonProperty("unique_subscriber_clicks")]
        public int UniqueSubscriberClicks { get; set; }

        [JsonProperty("click_rate")]
        public long ClickRate { get; set; }

        [JsonProperty("last_click")]
        public string LastClick { get; set; }
    }

    public class FacebookLikes
    {
        [JsonProperty("recipient_likes")]
        public int RecipientLikes { get; set; }

        [JsonProperty("unique_likes")]
        public int UniqueLikes { get; set; }

        [JsonProperty("facebook_likes")]
        public int FBLikes { get; set; }
    }

    public class IndustryStats
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("click_rate")]
        public long ClickRate { get; set; }

        [JsonProperty("bounce_rate")]
        public long BounceRate { get; set; }

        [JsonProperty("unopen_rate")]
        public long UnopenRate { get; set; }

        [JsonProperty("unsub_rate")]
        public long UnsubRate { get; set; }

        [JsonProperty("abuste_rate")]
        public long AbuseRate { get; set; }
    }

    public class ListStats
    {
        [JsonProperty("sub_rate")]
        public long SubscribeRate { get; set; }

        [JsonProperty("unsub_rate")]
        public long UnsubscribeRate { get; set; }

        [JsonProperty("open_rate")]
        public long OpenRate { get; set; }

        [JsonProperty("click_rate")]
        public long ClickRate { get; set; }
    }

    public class ABSplit
    {
        [JsonProperty("a")]
        public ABSplitItem A { get; set; }
        [JsonProperty("b")]
        public ABSplitItem B { get; set; }
    }

    public class ABSplitItem
    {
        [JsonProperty("bounces")]
        public int Bounces { get; set; }

        [JsonProperty("abuse_reports")]
        public int AbuseReports { get; set; }

        [JsonProperty("unsubs")]
        public int Unsubscribes { get; set; }

        [JsonProperty("recipient_clicks")]
        public int RecipientClicks { get; set; }

        [JsonProperty("fowards")]
        public int Forwards { get; set; }

        [JsonProperty("fowards_opens")]
        public int ForwardsOpens { get; set; }

        [JsonProperty("opens")]
        public int Opens { get; set; }

        [JsonProperty("last_open")]
        public string LastOpen { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }
    }

    public class Timewarp
    {
        [JsonProperty("gmt_offset")]
        public int GMTOffset { get; set; }

        [JsonProperty("opens")]
        public int Opens { get; set; }

        [JsonProperty("last_open")]
        public string LastOpen { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("clicks")]
        public int Clicks { get; set; }

        [JsonProperty("last_click")]
        public string LastClick { get; set; }

        [JsonProperty("unique_clicks")]
        public int UniqueClicks { get; set; }

        [JsonProperty("bounces")]
        public int Bounces { get; set; }
    }

    public class TimeSeries
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("emails_sent")]
        public int EmailsSent { get; set; }

        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        [JsonProperty("recipients_clicks")]
        public int RecipientsClicks { get; set; }
    }

    public class ShareReport
    {
        [JsonProperty("share_url")]
        public string ShareURL { get; set; }

        [JsonProperty("share_password")]
        public string SharePassword { get; set; }
    }
}
