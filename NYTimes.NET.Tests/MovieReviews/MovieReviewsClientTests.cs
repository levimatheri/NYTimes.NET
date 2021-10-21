using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.MovieReviews;
using NYTimes.NET.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.MovieReviews
{
    public class MovieReviewsClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;

        private MovieReviewsClient _movieReviewsClient;

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

            _movieReviewsClient = new MovieReviewsClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidGetMovieCriticsParams_ShouldThrowApiException(string reviewer)
        {
            Func<Task> action = async () => await _movieReviewsClient.GetMovieCritics(reviewer);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidGetMovieReviewsParams_ShouldThrowApiException(string type)
        {
            Func<Task> action = async () => await _movieReviewsClient.GetMovieReviews(type);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }


        [Test]
        public async Task Verify_GetMovieCriticsIsNotNull()
        {
            var critics = await _movieReviewsClient.GetMovieCritics("test");
            Assert.IsNotNull(critics);
        }

        [Test]
        public async Task Verify_GetMovieReviewsIsNotNull()
        {
            var reviews = await _movieReviewsClient.GetMovieReviews("test");
            Assert.IsNotNull(reviews);
        }

        [Test]
        public async Task Verify_SearchMovieReviewsIsNotNull()
        {
            var reviews = await _movieReviewsClient.SearchMovieReviews();
            Assert.IsNotNull(reviews);
        }
    }
}
