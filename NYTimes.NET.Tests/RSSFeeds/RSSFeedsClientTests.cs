using FluentAssertions;
using Moq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.RSSFeeds;
using NYTimes.NET.Models;
using NYTimes.NET.Tests.Mocks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.RSSFeeds
{
    [TestFixture]
    public class RSSFeedsClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;
        private Mock<IRestResponse<Rss>> _restResponse;

        private RSSFeedsClient _rssFeedsClient;

        [SetUp]
        public void Setup()
        {
            _client = new Mock<IAsynchronousClient>();
            _requestOptions = new Mock<IRequestOptions>();
            _readableConfig = new Mock<IReadableConfiguration>();

            _requestOptions.SetupGet(m => m.PathParameters).Returns(new Dictionary<string, string>());
            _requestOptions.SetupGet(m => m.QueryParameters).Returns(new Multimap<string, string>());
            _requestOptions.SetupGet(m => m.HeaderParameters).Returns(new Multimap<string, string>());

            _restResponse = new Mock<IRestResponse<Rss>>();
            _restResponse.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            _restResponse.SetupGet(r => r.Data).Returns(RSSFeedsMocks.GetMockRssFeedData());
            _restResponse.SetupGet(r => r.Content).Returns(RSSFeedsMocks.GetMockRssFeedDataAsXml());

            _client.Setup(c => c.GetAsync<Rss>(It.IsAny<string>(), It.IsAny<IRequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApiResponse<Rss>(HttpStatusCode.OK, RSSFeedsMocks.GetMockRssFeedData(), restSharpResponse: _restResponse.Object)));

            _rssFeedsClient = new RSSFeedsClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidSectionParam_ShouldThrowApiException(string section)
        {
            Func<Task> action = async () => await _rssFeedsClient.GetChannelArticles(section);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Verify_GetChannelArticlesIsNotNull()
        {
            var channel = await _rssFeedsClient.GetChannelArticles("test");
            Assert.IsNotNull(channel);
        }
    }
}
