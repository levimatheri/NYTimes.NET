using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;

namespace NYTimes.NET.Clients.RSSFeeds
{
    public class RSSFeedsClient : IRSSFeedsClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RSSFeedsClient"/> class.
        /// </summary>
        /// <returns></returns>
        public RSSFeedsClient()
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
        /// Initializes a new instance of the <see cref="RSSFeedsClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public RSSFeedsClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="RSSFeedsClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public RSSFeedsClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RSSFeedsClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public RSSFeedsClient(IAsynchronousClient asyncClient,
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
        /// Returns a list of articles for a given section. Given section name, return lists of articles ranked on the section front. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="section">Section name (Arts, Africa, Americas, ...).</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of channel articles</returns>
        public async Task<Channel> GetChannelArticles(string section, CancellationToken cancellationToken = default)
        {
            // verify the required parameter 'section' is set
            if (string.IsNullOrEmpty(section))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(section)} when calling {nameof(GetChannelArticles)}");


            string[] _accepts = new string[] {
                "application/xml"
            };

            var acceptHeader = ClientUtils.SelectHeaderAccept(_accepts);
            if (!string.IsNullOrEmpty(acceptHeader)) RequestOptions.HeaderParameters.Add("Accept", acceptHeader);

            var paramDictionary = new Dictionary<string, object>
            {
                { "section", section }
            };

            ClientUtils.AddRequestParams(RequestOptions, paramDictionary, true);

            var apiResponse = await this.AsynchronousClient.GetAsync<Rss>(
                    "/{section}.xml", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var xmlDeserializer = new RestSharp.Deserializers.DotNetXmlDeserializer();
            var resp = apiResponse.GetRestSharpResponse();
            var result = xmlDeserializer.Deserialize<Rss>(resp);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory(nameof(GetChannelArticles), apiResponse);
                if (_exception != null) throw _exception;
            }

            return result?.Channel;
        }
    }
}
