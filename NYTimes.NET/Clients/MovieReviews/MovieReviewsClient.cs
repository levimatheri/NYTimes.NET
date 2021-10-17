using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.MovieReviews
{
    public class MovieReviewsClient : IMovieReviewsClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieReviewsClient"/> class.
        /// </summary>
        /// <returns></returns>
        public MovieReviewsClient()
        {
            this.Configuration = ApiClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new ApiClientConfiguration { BasePath = GetBasePath() }
            );

            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieReviewsClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public MovieReviewsClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="MovieReviewsClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public MovieReviewsClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieReviewsClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public MovieReviewsClient(IAsynchronousClient asyncClient,
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
            return Constants.MovieReviewsApi.BaseUrl;
        }

        /// <summary>
        /// Get movie critics name, bio and image. You can either specify the reviewer name or use \&quot;all\&quot;, \&quot;full-time\&quot;, or \&quot;part-time\&quot;. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="reviewer">Reviewer name or \&quot;all\&quot; for all reviewers, \&quot;full-time\&quot; for full-time reviewers, or \&quot;part-time\&quot; for part-time reviewers.</param>
        /// <returns>Task of list of critics</returns>
        public async Task<IReadOnlyList<Critic>> GetMovieCritics(string reviewer, CancellationToken cancellationToken = default)
        {
            if (reviewer == null)
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(reviewer)} when calling {nameof(GetMovieCritics)}");

            var paramDictionary = new Dictionary<string, object>
            {
                { "reviewer", reviewer }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/critics/{reviewer}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<Critic>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetMovieCritics), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        /// Get movie reviews.  Can filter to only return Critics&#39; Picks. Supports ordering results by-publication-date or by-opening-date. Use offset to paginate thru results, 20 at a time. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter by critics&#39; pick or not.</param>
        /// <param name="offset">Sets the starting point of the result set.  Needs to be multiple of 20. (optional, default to 0)</param>
        /// <param name="order">How to order the results. (optional)</param>
        /// <returns>Task of list of reviews</returns>
        public async Task<IReadOnlyList<MovieReview>> GetMovieReviews(string type, int? offset = default, string order = default, CancellationToken cancellationToken = default)
        {
            if (type == null)
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(type)} when calling {nameof(GetMovieReviews)}");


            var queryParamDictionary = new Dictionary<string, object>
            {
                { "offset", offset },
                { "order", order }
            };

            ClientUtils.AddRequestParams(RequestOptions, queryParamDictionary);

            var pathParamDictionary = new Dictionary<string, object>
            {
                { "type", type }
            };

            ClientUtils.AddRequestParams(RequestOptions, pathParamDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/reviews/{type}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<MovieReview>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetMovieReviews), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        /// Search for movie reviews. Supports filtering by Critics&#39; Pick. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="criticsPick">Set to Y to only show critics&#39; picks.  Otherwise shows both. (optional)</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate thru results. Defaults to 0. The has_more field indicates the response has more results. (optional)</param>
        /// <param name="openingDate">U.S. opening date range. Start and end dates separated by colon (e.g. 1930-01-01:1940-01-01). (optional)</param>
        /// <param name="order">Field to order results by (e.g. by-publication-date). (optional)</param>
        /// <param name="publicationDate">Review publication date range. Start and end dates separated by colon (e.g. 1930-01-01:1940-01-01). (optional)</param>
        /// <param name="reviewer">Filter by reviewer byline (e.g. Stephen Holden). (optional)</param>
        /// <param name="query">Search keyword (e.g. lebowski). (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of reviews</returns>
        public async Task<IReadOnlyList<MovieReview>> SearchMovieReviews(string criticsPick = default, int? offset = default, string openingDate = default, string order = default, string publicationDate = default, string reviewer = default, string query = default, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                { "critics-pick", criticsPick },
                { "offset", offset },
                { "opening-date", openingDate },
                { "order", order },
                { "publication-date", publicationDate },
                { "reviewer", reviewer },
                { "query", query }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/reviews/search.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<MovieReview>>();

            var exception = ExceptionFactory?.Invoke(nameof(SearchMovieReviews), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
    }
}
