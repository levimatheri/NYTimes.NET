using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.TopStories
{
    public class TopStoriesClient : ITopStoriesClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopStoriesClient"/> class.
        /// </summary>
        /// <returns></returns>
        public TopStoriesClient()
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
        /// Initializes a new instance of the <see cref="TopStoriesClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public TopStoriesClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="TopStoriesClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public TopStoriesClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TopStoriesClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public TopStoriesClient(IAsynchronousClient asyncClient,
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
            return Constants.TopStoriesApi.BaseUrl;
        }

        /// <summary>
        ///  Gets articles currently on the specified section.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="url">The complete URL of a specific news item, URL-encoded or backslash-escaped</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of articles</returns>
        public async Task<IReadOnlyList<Article>> GetArticlesBySection(string section, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(section))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(section)} when calling {nameof(GetArticlesBySection)}");

            var paramDictionary = new Dictionary<string, object>
            {
                { "section", section }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/{section}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<NewsArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetArticlesBySection), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
    }
}
