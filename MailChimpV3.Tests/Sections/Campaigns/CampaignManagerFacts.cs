using System.Threading.Tasks;
using MailChimpV3API;
using MailChimpV3API.Sections.Campaigns;
using Xunit;

namespace MailChimpV3.Tests.Sections.Campaigns
{
    public class GetMany
    {
        public GetMany()
        {
            var apiKey = string.Empty;

            var mailchimpFactory = new MailChimpFactory();
            _mailchimp = mailchimpFactory.Create(apiKey);
        }

        private readonly IMailChimp _mailchimp;

        [Fact]
        public async Task GetSpecificFieldsForCollection()
        {
            var campaigns = await _mailchimp.Campaigns.GetManyAsync(
                new CampaignCollectionFilter
                {
                    IncludeFields = new[] { "campaigns.settings.title" }
                });

            Assert.NotEmpty(campaigns.Campaigns);
            foreach (var campaign in campaigns.Campaigns)
            {
                Assert.NotNull(campaign.Settings);
                Assert.NotNull(campaign.Settings.Title);
                Assert.Null(campaign.Settings.ToName);
                Assert.Null(campaign.Recipients);
            }
        }

        [Fact]
        public async Task GetSpecificSubFieldsForCollection()
        {
            var campaigns = await _mailchimp.Campaigns.GetManyAsync(
                new CampaignCollectionFilter
                {
                    IncludeFields = new[] { "campaigns.status", "campaigns.settings" }
                });

            Assert.NotEmpty(campaigns.Campaigns);
            foreach (var campaign in campaigns.Campaigns)
            {
                Assert.NotNull(campaign.Settings);
                Assert.NotNull(campaign.Status);
                Assert.Null(campaign.Recipients);
            }
        }
    }

    public class GetSingle
    {
        public GetSingle()
        {
            var apiKey = string.Empty;

            var mailchimpFactory = new MailChimpFactory();
            _mailchimp = mailchimpFactory.Create(apiKey);
        }

        private readonly IMailChimp _mailchimp;

        [Fact]
        public async Task GetSpecificFields()
        {
            var campaign = await _mailchimp.Campaigns.GetSingleAsync(
                "85f73d0253",
                new MailChimpFieldFilter
                {
                    IncludeFields = new[] { "create_time", "status" }
                });

            Assert.NotNull(campaign);
            Assert.NotNull(campaign.CreateTime);
            Assert.NotEmpty(campaign.Status);
            Assert.Null(campaign.Settings);
            Assert.Null(campaign.SendTime);
            Assert.Null(campaign.Recipients);
        }
    }
}