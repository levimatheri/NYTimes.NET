using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYTimes.NET.Models;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.Archive
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ArchiveClient : IArchiveClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveClient"/> class.
        /// </summary>
        /// <returns></returns>
        public ArchiveClient()
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
        /// Initializes a new instance of the <see cref="ArchiveClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public ArchiveClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="ArchiveClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public ArchiveClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchiveClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public ArchiveClient(IAsynchronousClient asyncClient,
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
            return Constants.ArchiveApi.BaseUrl;
        }

        /// <summary>
        /// Returns an array of articles for a given month. Pass in year and month and get back JSON with all articles for that month. The response can be big (~20 megabytes) and contain thousands of articles, depending on the year and month. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="year">Year: 1851-2019</param>
        /// <param name="month">Year: 1-12</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of a readonly list of <see cref="Article"/></returns>
        public async Task<IReadOnlyList<Article>> GetAllMonthArticles(int year, int month, CancellationToken cancellationToken = default)
        {
            RequestOptions.PathParameters.Add("year", ClientUtils.ParameterToString(year));
            RequestOptions.PathParameters.Add("month", ClientUtils.ParameterToString(month));
            
            var wrappedResponse = await this.AsynchronousClient
                .GetAsync<JObject>("/{year}/{month}.json", this.RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var articles = wrappedResponse.Data
                .SelectToken("response.docs")?
                .ToObject<IReadOnlyList<Article>>();

            if (this.ExceptionFactory == null) return articles;
            var exception = this.ExceptionFactory(nameof(GetAllMonthArticles), wrappedResponse);
            if (exception != null) throw exception;

            return articles;
        }
    }
}