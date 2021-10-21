using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.Semantic;
using NYTimes.NET.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.Semantic
{
    public class SemanticClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;

        private SemanticClient _semanticClient;

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

            _semanticClient = new SemanticClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [TestCase(null, "test", "test")]
        [TestCase("", "test", "test")]
        [TestCase("test", "", "test")]
        [TestCase("test", null, "test")]
        [TestCase("test", "test", "")]
        [TestCase("test", "test", null)]
        public async Task InvalidGetConceptParams_ShouldThrowApiException(string conceptType, string specificConcept, string query)
        {
            Func<Task> action = async () => await _semanticClient.GetConcepts(conceptType, specificConcept, query);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidSearchConceptParams_ShouldThrowApiException(string query)
        {
            Func<Task> action = async () => await _semanticClient.SearchConcept(query);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Verify_GetConceptResultIsNotNull()
        {
            var concepts = await _semanticClient.GetConcepts("test", "test", "test");
            Assert.IsNotNull(concepts);
        }

        [Test]
        public async Task Verify_SearchConceptResultIsNotNull()
        {
            var concepts = await _semanticClient.SearchConcept("test");
            Assert.IsNotNull(concepts);
        }
    }
}
