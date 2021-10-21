using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.MostPopular
{
    public class MostPopularClient : IMostPopularClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MostPopularClient"/> class.
        /// </summary>
        /// <returns></returns>
        public MostPopularClient()
        {
            this.Configuration = ApiClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new ApiClientConfiguration { BasePath = GetBasePath() }
            );

            this.RequestOptions = new RequestOptions(this.Configuration);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MostPopularClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public MostPopularClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="MostPopularClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public MostPopularClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MostPopularClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public MostPopularClient(IAsynchronousClient asyncClient,
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
            return Constants.MostPopularApi.BaseUrl;
        }

        /// <summary>
        /// Gets the most emailed articles on NYTimes.com for specified period of time (1 day, 7 days, or 30 days). 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="period">Time period: 1, 7, or 30 days.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of Articles</returns>
        public async Task<IReadOnlyList<Article>> GetMostEmailedArticlesByPeriod(int period, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                { "period", period }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/emailed/{period}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<EmailedArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetMostEmailedArticlesByPeriod), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        /// Gets the most shared articles on NYTimes.com for specified period of time (1 day, 7 days, or 30 days). 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="period">Time period: 1, 7, or 30 days.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of Articles</returns>
        public async Task<IReadOnlyList<Article>> GetMostSharedArticlesByPeriod(int period, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                { "period", period }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/shared/{period}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<SharedArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetMostSharedArticlesByPeriod), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        /// Gets the most shared articles by share type on NYTimes.com for specified period of time (1 day, 7 days, or 30 days). 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// /// <param name="shareType">Share type: facebook.</param>
        /// <param name="period">Time period: 1, 7, or 30 days.</param>
        /// <returns>Task of list of Articles</returns>
        public async Task<IReadOnlyList<Article>> GetMostSharedArticlesByPeriodAndShareType(string shareType, int period, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(shareType))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(shareType)} when calling {nameof(GetMostSharedArticlesByPeriodAndShareType)}");

            var paramDictionary = new Dictionary<string, object>
            {
                { "share_type", shareType },
                { "period", period }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/shared/{period}/{share_type}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<SharedArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetMostSharedArticlesByPeriodAndShareType), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        /// Gets the most viewed articles on NYTimes.com for specified period of time (1 day, 7 days, or 30 days). 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="period">Time period: 1, 7, or 30 days.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of Articles</returns>
        public async Task<IReadOnlyList<Article>> GetMostViewedArticlesByPeriod(int period, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                { "period", period }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/viewed/{period}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<SharedArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetMostViewedArticlesByPeriod), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
    }
}
