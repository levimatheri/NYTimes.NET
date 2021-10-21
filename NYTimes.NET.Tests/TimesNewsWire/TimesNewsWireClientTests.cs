using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.TimesNewsWire;
using NYTimes.NET.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.TimesNewsWire
{
    public class TimesNewsWireClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;

        private TimesNewsWireClient _timesNewsWireClient;

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

            _timesNewsWireClient = new TimesNewsWireClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidUrl_ShouldThrowApiException(string url)
        {
            Func<Task> action = async () => await _timesNewsWireClient.GetContent(url);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [TestCase(null, "food")]
        [TestCase("", "food")]
        [TestCase("nytimes", "")]
        [TestCase("nytimes", null)]
        public async Task InvalidSourceOrSection_ShouldThrowApiException(string source, string section)
        {
            Func<Task> action = async () => await _timesNewsWireClient.GetContentBySourceAndSection(source, section);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Verify_ResultIsNotNull()
        {
            var articles = await _timesNewsWireClient.GetContent("https://example.com");
            Assert.IsNotNull(articles);
        }

        [Test]
        public async Task Verify_ContentBySectionAndSourceIsNotNull()
        {
            var articles = await _timesNewsWireClient.GetContentBySourceAndSection("nytimes", "food");
            Assert.IsNotNull(articles);
        }

        [Test]
        public async Task Verify_SectionListIsNotNull()
        {
            var sectionList = await _timesNewsWireClient.GetContentSectionList();
            Assert.IsNotNull(sectionList);
        }
    }
}
