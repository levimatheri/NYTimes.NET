using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.Books
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BooksClient : IBooksClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksClient"/> class.
        /// </summary>
        /// <returns></returns>
        public BooksClient()
        {
            this.Configuration = ApiClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new ApiClientConfiguration { BasePath = GetBasePath() }
            );
            
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public BooksClient(IReadableConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            this.Configuration = ApiClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                configuration
            );
            
            this.RequestOptions = new RequestOptions(this.Configuration);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public BooksClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public BooksClient(IAsynchronousClient asyncClient,
            IRequestOptions requestOptions, IReadableConfiguration configuration)
        {
            this.AsynchronousClient = asyncClient ?? throw new ArgumentNullException(nameof(asyncClient));
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.RequestOptions = requestOptions ?? throw new ArgumentNullException(nameof(requestOptions));
            this.ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }
        
        public IAsynchronousClient AsynchronousClient { get; set; }
        
        public IReadableConfiguration Configuration { get; set; }
        
        public IRequestOptions RequestOptions { get; set; }
        
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }
        
        public string GetBasePath()
        {
            return Constants.ArticleSearchApi.BaseUrl;
        }

        /// <summary>
        /// Get Best Sellers list.  If no date is provided returns the latest list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="list">The name of the Times best sellers list (hardcover-fiction, paperback-nonfiction, ...).
        /// The /lists/names service returns all the list names. The encoded list names are lower case with hyphens instead of spaces (e.g. e-book-fiction, instead of E-Book Fiction).</param>
        /// <param name="bestsellersDate">YYYY-MM-DD  The week-ending date for the sales reflected on list-name. Times best sellers lists are compiled using available book sale data.
        /// The bestsellers-date may be significantly earlier than published-date. For additional information, see the explanation at the bottom of any best-seller list page on NYTimes.com
        /// (example: Hardcover Fiction, published Dec. 5 but reflecting sales to Nov. 29). (optional)</param>
        /// <param name="publishedDate">YYYY-MM-DD  The date the best sellers list was published on NYTimes.com (different than bestsellers-date).  Use \&quot;current\&quot; for latest list. (optional)</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate through books if list has more than 20. Defaults to 0.  The num_results field indicates how many books are in the list. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List of <see cref="Book"/>s</returns>
        public async Task<IReadOnlyList<Book>> GetBestSellersList(string list, string bestsellersDate = default, string publishedDate = default,
            int? offset = default, CancellationToken cancellationToken = default)
        {
            if (list == null)
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter 'list' when calling {nameof(GetBestSellersList)}");
            
            var paramDictionary = new Dictionary<string, object>
            {
                {"list", list},
                {"bestsellers-date", bestsellersDate},
                {"published-date", publishedDate},
                {"offset", offset}
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                "/lists.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);
            
            var books = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<Book>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetBestSellersList), wrappedResponse);
            if (exception != null) throw exception;

            return books;
        }
        
        /// <summary>
        /// Get Best Sellers list names.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of list of <see cref="BestSellerListName"/></returns>
        public async Task<IReadOnlyList<BestSellerListName>> GetBestSellerListNames(CancellationToken cancellationToken = default)
        {
            // make the HTTP request
            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/lists/names.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);
            
            var bestSellerListNames = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<BestSellerListName>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetBestSellerListNames), wrappedResponse);
            if (exception != null) throw exception;

            return bestSellerListNames;
        }

        /// <summary>
        /// Get top 5 books for all the Best Sellers lists for specified date.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="publishedDate">YYYY-MM-DD  The best-seller list publication date. You do not have to specify the exact date the list was published.
        /// The service will search forward (into the future) for the closest publication date to the date you specify.
        /// For example, a request for lists/overview/2013-05-22 will retrieve the list that was published on 05-26.
        /// If you do not include a published date, the current week&#39;s best sellers lists will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of <see cref="BestSellerOverview"/></returns>
        public async Task<BestSellerOverview> GetBestSellerOverview(string publishedDate = default, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                { "published_date", publishedDate }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);

            // make the HTTP request
            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/lists/overview.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);
            
            var bestSellerOverview = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<BestSellerOverview>();

            var exception = ExceptionFactory?.Invoke(nameof(GetBestSellerOverview), wrappedResponse);
            if (exception != null) throw exception;

            return bestSellerOverview;
        }
        
        /// <summary>
        /// Get book reviews.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="isbn">Searching by ISBN is the recommended method. You can enter 10- or 13-digit ISBNs. (optional)</param>
        /// <param name="title">You’ll need to enter the full title of the book. Spaces in the title will be converted into the characters %20. (optional)</param>
        /// <param name="author">You’ll need to enter the author’s first and last name, separated by a space. This space will be converted into the characters %20. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of <see cref="BookReview"/></returns>
        public async Task<IReadOnlyList<BookReview>> GetBookReviews(long? isbn = default, string title = default, string author = default, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                {"isbn", isbn},
                {"title", title},
                {"author", author},
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);

            // make the HTTP request
            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/reviews.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);
            
            var bestSellerOverview = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<BookReview>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetBookReviews), wrappedResponse);
            if (exception != null) throw exception;

            return bestSellerOverview;
        }

        /// <summary>
        /// Get Best Sellers list by date.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="date">YYYY-MM-DD or \&quot;current\&quot;  The date the best sellers list was published on NYTimes.com.  Use \&quot;current\&quot; to get latest list.</param>
        /// <param name="list">Name of the Best Sellers List (e.g. hardcover-fiction). You can get the full list of names from the /lists/names.json service.</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate thru books if list has more than 20. Defaults to 0.  The num_results field indicates how many books are in the list. (optional)</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        public async Task<BestSellerOverview> GetBestSellersListByDate(string date, string list, int? offset = default, CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'date' is set
            if (date == null)
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter 'date' when calling {nameof(GetBestSellersListByDate)}");

            // verify the required parameter 'list' is set
            if (list == null)
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter 'list' when calling {nameof(GetBestSellersListByDate)}");

            var paramDictionary = new Dictionary<string, object>
            {
                {"date", date},
                {"list", list},
                {"offset", offset},
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/lists/{date}/{list}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);
            
            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<BestSellerDetail>();
            
            var exception = ExceptionFactory?.Invoke(nameof(GetBestSellersListByDate), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
        
        /// <summary>
        /// Get Best Sellers list history.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="ageGroup">The target age group for the best seller. (optional)</param>
        /// <param name="author">The author of the best seller. The author field does not include additional contributors (see Data Structure for more details about the author and contributor fields).
        /// When searching the author field, you can specify any combination of first, middle and last names.  When sort-by is set to author, the results will be sorted by author&#39;s first name. (optional)</param>
        /// <param name="contributor">The author of the best seller, as well as other contributors such as the illustrator (to search or sort by author name only, use author instead).
        /// When searching, you can specify any combination of first, middle and last names of any of the contributors.
        /// When sort-by is set to contributor, the results will be sorted by the first name of the first contributor listed. (optional)</param>
        /// <param name="isbn">International Standard Book Number, 10 or 13 digits  A best seller may have both 10-digit and 13-digit ISBNs, and may have multiple ISBNs of each type.
        /// To search on multiple ISBNs, separate the ISBNs with semicolons (example: 9780446579933;0061374229). (optional)</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate thru results if there are more than 20. Defaults to 0.
        /// The num_results field indicates how many results there are total. (optional)</param>
        /// <param name="price">The publisher&#39;s list price of the best seller, including decimal point. (optional)</param>
        /// <param name="publisher">The standardized name of the publisher (optional)</param>
        /// <param name="title">The title of the best seller  When searching, you can specify a portion of a title or a full title. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of BestSellerHistory </returns>
        public async Task<IReadOnlyList<BestSellerBook>> GetBestSellersListHistory(string ageGroup = default, string author = default, string contributor = default, 
            string isbn = default, int? offset = default, string price = default, string publisher = default, string title = default, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                {"age-group", ageGroup},
                {"author", author},
                {"contributor", contributor},
                {"isbn", isbn},
                {"offset", offset},
                {"price", price},
                {"publisher", publisher},
                {"title", title}
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/lists/best-sellers/history.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);
            
            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<BestSellerHistory>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetBestSellersListHistory), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
    }
}