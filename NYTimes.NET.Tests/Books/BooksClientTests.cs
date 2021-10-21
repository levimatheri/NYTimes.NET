using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NYTimes.NET.Clients;
using NYTimes.NET.Clients.Books;
using NYTimes.NET.Models;
using NYTimes.NET.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Tests.Books
{
    public class BooksClientTests
    {
        private Mock<IAsynchronousClient> _client;
        private Mock<IRequestOptions> _requestOptions;
        private Mock<IReadableConfiguration> _readableConfig;

        private BooksClient _booksClient;

        [SetUp]
        public void Setup()
        {
            _client = new Mock<IAsynchronousClient>();
            _requestOptions = new Mock<IRequestOptions>();
            _readableConfig = new Mock<IReadableConfiguration>();

            _client.Setup(c => c.GetAsync<JObject>(It.IsAny<string>(), It.IsAny<IRequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApiResponse<JObject>(HttpStatusCode.OK, GeneralUseMocks.GetEmptyJArray())));

            _requestOptions.SetupGet(m => m.PathParameters).Returns(new Dictionary<string, string>());
            _requestOptions.SetupGet(m => m.QueryParameters).Returns(new Multimap<string, string>());

            _booksClient = new BooksClient(_client.Object, _requestOptions.Object, _readableConfig.Object);
        }

        [Test]
        public async Task Verify_GetBestSellersListIsNotNull()
        {
            var list = await _booksClient.GetBestSellersList("test");
            Assert.IsNotNull(list);
        }

        [Test]
        public async Task Verify_GetBestSellersListNamesIsNotNull()
        {
            var listNames = await _booksClient.GetBestSellerListNames();
            Assert.IsNotNull(listNames);
        }

        [Test]
        public async Task Verify_GetBookReviewsIsNotNull()
        {
            var reviews = await _booksClient.GetBookReviews();
            Assert.IsNotNull(reviews);
        }

        [Test]
        public async Task Verify_GetBestSellersListHistoryIsNotNull()
        {
            var listHistory = await _booksClient.GetBestSellersListHistory();
            Assert.IsNotNull(listHistory);
        }

        [Test]
        public async Task Verify_GetBestSellerOverviewIsNotNull()
        {
            _client.Setup(c => c.GetAsync<JObject>(It.IsAny<string>(), It.IsAny<IRequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApiResponse<JObject>(HttpStatusCode.OK, GeneralUseMocks.GetEmptyJObject<BestSellerOverview>())));
            var overview = await _booksClient.GetBestSellerOverview();
            Assert.IsNotNull(overview);
        }

        [Test]
        public async Task Verify_GetBestSellersListByDateIsNotNull()
        {
            _client.Setup(c => c.GetAsync<JObject>(It.IsAny<string>(), It.IsAny<IRequestOptions>(), It.IsAny<IReadableConfiguration>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApiResponse<JObject>(HttpStatusCode.OK, GeneralUseMocks.GetEmptyJObject<BestSellerOverview>())));
            var overview = await _booksClient.GetBestSellersListByDate("01-01-2021", "test");
            Assert.IsNotNull(overview);
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task InvalidGetBestSellersListParam_ShouldThrowApiException(string list)
        {
            Func<Task> action = async () => await _booksClient.GetBestSellersList(list);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [TestCase(null, "test")]
        [TestCase("", "test")]
        [TestCase("01-01-2021", "")]
        [TestCase("01-01-2021", null)]
        public async Task InvalidGetBestSellersListByDateParam_ShouldThrowApiException(string date, string list)
        {
            Func<Task> action = async () => await _booksClient.GetBestSellersListByDate(date, list);
            (await action.Should().ThrowAsync<ApiException>())
                .And.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
