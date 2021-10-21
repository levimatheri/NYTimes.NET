using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.ArticleSearch
{
    public class ArticleSearchClient : IArticleSearchClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleSearchClient"/> class.
        /// </summary>
        /// <returns></returns>
        public ArticleSearchClient()
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
        /// Initializes a new instance of the <see cref="ArticleSearchClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public ArticleSearchClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="ArticleSearchClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public ArticleSearchClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleSearchClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public ArticleSearchClient(IAsynchronousClient asyncClient,
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
        /// Returns an array of articles. Search for NYT articles by keywords, filters and facets.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="beginDate">Begin date (e.g. 20120101) (optional)</param>
        /// <param name="endDate">End date (e.g. 20121231) (optional)</param>
        /// <param name="facet">Whether to show facet counts (optional)</param>
        /// <param name="facetFields">Facets (optional)</param>
        /// <param name="facetFilter">Have facet counts use filters (optional)</param>
        /// <param name="fl">Field list (optional)</param>
        /// <param name="fq">Filter query (optional)</param>
        /// <param name="page">Page number (0, 1, ...) (optional)</param>
        /// <param name="q">Query (optional)</param>
        /// <param name="sort">Sort order (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of a readonly list of <see cref="Article"/></returns>
        public async Task<IReadOnlyList<Article>> SearchArticles(string beginDate = default, string endDate = default,
            string facet = default, string facetFields = default, string facetFilter = default, string fl = default, string fq = default,
            int? page = default, string q = default, string sort = default, CancellationToken cancellationToken = default)
        {
            var paramDictionary = new Dictionary<string, object>
            {
                {"begin_date", beginDate},
                {"end_date", endDate},
                {"facet", facet},
                {"facet_fields", facetFields},
                {"facet_filter", facetFilter},
                {"fl", fl},
                {"fq", fq},
                {"page", page},
                {"q", q},
                {"sort", sort},
            };
            
            ClientUtils.AddRequestParams(RequestOptions, paramDictionary);
            
            var wrappedResponse = await this.AsynchronousClient
                .GetAsync<JObject>("/articlesearch.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var articles = wrappedResponse.Data
                .SelectToken("response.docs")?
                .ToObject<IReadOnlyList<Article>>();

            if (this.ExceptionFactory == null) return articles;
            var exception = this.ExceptionFactory(nameof(SearchArticles), wrappedResponse);
            if (exception != null) throw exception;

            return articles;
        }  
    }
}