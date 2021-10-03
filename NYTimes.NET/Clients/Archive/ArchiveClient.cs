using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYTimes.NET.Models.Archive;
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
            
            this.Client = new ApiClient(this.Configuration.BasePath);
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
            this.Client = new ApiClient(this.Configuration.BasePath);
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
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public ArchiveClient(ISynchronousClient client, IAsynchronousClient asyncClient,
            IRequestOptions requestOptions, IReadableConfiguration configuration)
        {
            this.Client = client ?? throw new ArgumentNullException(nameof(client));
            this.AsynchronousClient = asyncClient ?? throw new ArgumentNullException(nameof(asyncClient));
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.RequestOptions = requestOptions ?? throw new ArgumentNullException(nameof(requestOptions));
            this.ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }
        
        public IAsynchronousClient AsynchronousClient { get; set; }
        
        public ISynchronousClient Client { get; set; }
        
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
            var exception = this.ExceptionFactory("YearMonthJsonGet", wrappedResponse);
            if (exception != null) throw exception;

            return articles;
        }
    }
}