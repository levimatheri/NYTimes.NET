using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.TimesNewsWire
{
    public class TimesNewsWireClient : ITimesNewsWireClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesNewsWireClient"/> class.
        /// </summary>
        /// <returns></returns>
        public TimesNewsWireClient()
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
        /// Initializes a new instance of the <see cref="TimesNewsWireClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public TimesNewsWireClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="TimesNewsWireClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public TimesNewsWireClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimesNewsWireClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public TimesNewsWireClient(IAsynchronousClient asyncClient,
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
            return Constants.TimesNewsWireApi.BaseUrl;
        }

        /// <summary>
        ///  Get content.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="url">The complete URL of a specific news item, URL-encoded or backslash-escaped</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of articles</returns>
        public async Task<IReadOnlyList<Article>> GetContent(string url, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(url)} when calling {nameof(GetContent)}");

            var paramDictionary = new Dictionary<string, object>
            {
                { "url", url }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/content.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<NewsArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetContent), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        ///  Get content by source and section.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="source">Limits the set of items by originating source.  all &#x3D; items from both The New York Times and The International New York Times nyt &#x3D; New York Times items only inyt &#x3D; International New York Times items only (FKA The International Herald Tribune) </param>
        /// <param name="section">Limits the set of items by a section. all | A section name   To get all sections, specify all. To get a particular section, use the section name returned by this request:  http://api.nytimes.com/svc/news/v3/content/section-list.json </param>
        /// <param name="limit">Limits the number of results.  Set to increment of 20 up to 500. (optional, default to 20)</param>
        /// <param name="offset">Sets the starting point of the result set. (optional, default to 0)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of articles</returns>
        public async Task<IReadOnlyList<Article>> GetContentBySourceAndSection(string source, string section, int? limit = default, int? offset = default, CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'source' is set
            if (string.IsNullOrWhiteSpace(source))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(source)} when calling {nameof(GetContentBySourceAndSection)}");

            // verify the required parameter 'section' is set
            if (string.IsNullOrWhiteSpace(section))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(section)} when calling {nameof(GetContentBySourceAndSection)}");

            var pathParamDictionary = new Dictionary<string, object>
            {
                { "source", source },
                { "section", section }
            };

            var queryParamDictionary = new Dictionary<string, object>
            {
                { "limit", limit },
                { "offset", offset }
            };

            ClientUtils.AddRequestParams(RequestOptions, pathParamDictionary, true);
            ClientUtils.AddRequestParams(RequestOptions, queryParamDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/content/{source}/{section}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<NewsArticle>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetContentBySourceAndSection), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        ///  Get content section list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of sections</returns>
        public async Task<IReadOnlyList<Section>> GetContentSectionList(CancellationToken cancellationToken = default)
        {
            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/content/section-list.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<Section>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetContentSectionList), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
    }
}
