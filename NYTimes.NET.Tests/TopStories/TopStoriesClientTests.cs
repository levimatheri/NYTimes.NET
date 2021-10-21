using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.TopStories;
using NYTimes.NET.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.TopStories
{
    [TestFixture]
    public class TopStoriesClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;

        private TopStoriesClient _topStoriesClient;

        [SetUp]
        public void Setup()
        {
            _client = new Mock<IAsynchronousClient>();
            _requestOptions = new Mock<IRequestOptions>();
            _readableConfig = new Mock<IReadableConfiguration>();

            _requestOptions.SetupGet(m => m.PathParameters).Returns(new Dictionary<string, string>());

            _topStoriesClient = new TopStoriesClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidSection_ShouldThrowApiException(string section)
        {
            Func<Task> action = async () => await _topStoriesClient.GetArticlesBySection(section);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Verify_TopStoriesListIsNotNull()
        {
            _client.Setup(c => c.GetAsync<JObject>(It.IsAny<string>(), It.IsAny<IRequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApiResponse<JObject>(HttpStatusCode.OK, GeneralUseMocks.GetEmptyJArray())));

            var topStories = await _topStoriesClient.GetArticlesBySection("test");
            Assert.IsNotNull(topStories);
        }
    }
}
