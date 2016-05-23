using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailChimpV3API;
using MailChimpV3API.Sections.Campaigns;
using Xunit;

namespace MailChimpV3.Tests.Sections.Campaigns
{
    public class CampaignContentManagerFacts
    {
        private readonly IMailChimp _mailchimp;

        public CampaignContentManagerFacts()
        {
            var apiKey = string.Empty;

            var mailchimpFactory = new MailChimpFactory();
            _mailchimp = mailchimpFactory.Create(apiKey);
        }

        [Fact]
        public async Task GetSpecificFieldsForCollection()
        {
            var campaigns = await _mailchimp.Campaigns.GetManyAsync();

            Assert.NotEmpty(campaigns.Campaigns);
            foreach (var campaign in campaigns.Campaigns)
            {
                var content = await _mailchimp.Campaigns.ContentManager.GetAsync(campaign.Id);
                Assert.NotNull(content);
            }
        }
    }
}
