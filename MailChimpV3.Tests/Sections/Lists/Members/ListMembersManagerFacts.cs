using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailChimpV3API;
using MailChimpV3API.Sections.Lists.Members;
using Xunit;

namespace MailChimpV3.Tests.Sections.Lists.Members
{
    public class ListMembersManagerFacts
    {
        public class GetAllAsync
        {
            private readonly IMailChimp _mailchimp;

            public GetAllAsync()
            {
                var apiKey = string.Empty;

                var mailchimpFactory = new MailChimpFactory();
                _mailchimp = mailchimpFactory.Create(apiKey);
            }

            [Theory]
            [InlineData("1d9f7df101", 3)]
            [InlineData("30e8c09fe1", 90158)]
            public async Task SuccessfullyDownloadsListMembers(string listId, int expectedCount)
            {
                var stopwatch = Stopwatch.StartNew();
                var members = await _mailchimp.Lists.Members.GetAllAsync(listId, new ListMembersFilter
                {
                    Count = 500,
                    Status = MailChimpListMember.Statuses.Subscribed,
                    IncludeFields = new[]
                    {
                        "total_items",
                        "members.email_address",
                        "members.merge_fields"
                    }
                });

                stopwatch.Stop();

                Assert.Equal(expectedCount, members.Count());
            }

            [Fact]
            public async Task SuccessfullyFiltersListMembersWithDate()
            {
                var members = await _mailchimp.Lists.Members.GetAllAsync("1d9f7df101", new ListMembersFilter { SinceLastChanged = new DateTime(2015, 01, 01) });

                Assert.Equal(1, members.Count());
            }

            [Fact]
            public async Task SuccessfullyFiltersListMembersWithEnum()
            {
                var members = await _mailchimp.Lists.Members.GetAllAsync("1d9f7df101", new ListMembersFilter
                {
                    SortField = ListMembersFilter.SortFields.LastChanged, 
                    SortDirection = CollectionSortDirection.Descending
                });

                Assert.Equal(3, members.Count());
                Assert.Equal("alex@koan.is", members.First().EmailAddress);
            }
        }
    }
}
