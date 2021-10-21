using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.MostPopular;
using NYTimes.NET.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.MostPopular
{
    public class MostPopularClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;

        private MostPopularClient _mostPopularClient;

        [SetUp]
        public void Setup()
        {
            _client = new Mock<IAsynchronousClient>();
            _requestOptions = new Mock<IRequestOptions>();
            _readableConfig = new Mock<IReadableConfiguration>();

            _requestOptions.SetupGet(m => m.PathParameters).Returns(new Dictionary<string, string>());
            _requestOptions.SetupGet(m => m.QueryParameters).Returns(new Multimap<string, string>());

            _client.Setup(c => c.GetAsync<JObject>(It.IsAny<string>(), It.IsAny<IRequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApiResponse<JObject>(HttpStatusCode.OK, GeneralUseMocks.GetEmptyJArray())));

            _mostPopularClient = new MostPopularClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [Test]
        public async Task Verify_GetMostEmailedArticlesByPeriodIsNotNull()
        {
            var articles = await _mostPopularClient.GetMostEmailedArticlesByPeriod(1);
            Assert.IsNotNull(articles);
        }

        [Test]
        public async Task Verify_GetMostSharedArticlesByPeriodIsNotNull()
        {
            var articles = await _mostPopularClient.GetMostSharedArticlesByPeriod(1);
            Assert.IsNotNull(articles);
        }

        [Test]
        public async Task Verify_GetMostViewedArticlesByPeriodIsNotNull()
        {
            var articles = await _mostPopularClient.GetMostViewedArticlesByPeriod(1);
            Assert.IsNotNull(articles);
        }

        [TestCase(null, 1)]
        [TestCase("", 1)]
        public async Task InvalidShareTypeParam_ShouldThrowApiException(string shareType, int period)
        {
            Func<Task> action = async () => await _mostPopularClient.GetMostSharedArticlesByPeriodAndShareType(shareType, period);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
