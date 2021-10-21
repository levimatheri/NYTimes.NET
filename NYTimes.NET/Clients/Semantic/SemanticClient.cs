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

namespace NYTimes.NET.Clients.Semantic
{
    public class SemanticClient : ISemanticClient
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticClient"/> class.
        /// </summary>
        /// <returns></returns>
        public SemanticClient()
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
        /// Initializes a new instance of the <see cref="SemanticClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of <see cref="IReadableConfiguration"/></param>
        /// <returns></returns>
        public SemanticClient(IReadableConfiguration configuration)
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
        /// Initializes a new instance of the <see cref="SemanticClient"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="requestOptions">An implementation of <see cref="IRequestOptions"/></param>
        /// <returns></returns>
        public SemanticClient(IRequestOptions requestOptions) : this()
        {
            this.RequestOptions = requestOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticClient"/> class
        /// using a <see cref="IReadableConfiguration"/> instance, a <see cref="IRequestOptions"/> instance and client instance.
        /// </summary>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="requestOptions">The request options object</param>
        /// <param name="configuration">The configuration object.</param>
        public SemanticClient(IAsynchronousClient asyncClient,
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
            return Constants.SemanticApi.BaseUrl;
        }

        /// <summary>
        ///  Gets concepts.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="conceptType">The type of the concept, used for Constructing a Semantic API Request by Concept Type and Specific Concept Name. The parameter is defined as a name-value pair, as in \&quot;concept_type&#x3D;[nytd_geo|nytd_per|nytd_org|nytd_des]\&quot;. </param>
        /// <param name="specificConcept">The name of the concept, used for Constructing a Semantic API Request by Concept Type and Specific Concept Name. The parameter is defined in the URI path, as the element immediately preceding \&quot;.json\&quot; like with \&quot;Baseball.json\&quot;. </param>
        /// <param name="query">Precedes the search term string. Used in a Search Query. Except for &amp;lt;specific_concept_name&amp;gt;, Search Query will take the required parameters listed above (&amp;lt;concept_type&amp;gt;, &amp;lt;concept_uri&amp;gt;, &amp;lt;article_uri&amp;gt;) as an optional_parameter in addition to the query&#x3D;&amp;lt;query_term&amp;gt;.</param>
        /// <param name="fields">\&quot;all\&quot; or comma-separated list of specific optional fields: pages, ticker_symbol, links, taxonomy, combinations, geocodes, article_list, scope_notes, search_api_query  Optional fields are returned in result_set. They are briefly explained here:  pages: A list of topic pages associated with a specific concept. ticker_symbol: If this concept is a publicly traded company, this field contains the ticker symbol.
        /// links: A list of links from this concept to external data resources. 
        /// taxonomy: For descriptor concepts, this field returns a list of taxonomic relations to other concepts. 
        /// combinations: For descriptor concepts, this field returns a list of the specific meanings tis concept takes on when combined with other concepts. 
        /// geocodes: For geographic concepts, the full GIS record from geonames. 
        /// article_list: A list of up to 10 articles associated with this concept. 
        /// scope_notes: Scope notes contains clarifications and meaning definitions that explicate the relationship between the concept and an article. 
        /// search_api_query: Returns the request one would need to submit to the Article Search API to obtain a list of articles annotated with this concept. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of concepts</returns>
        public async Task<IReadOnlyList<Concept>> GetConcepts(string conceptType, string specificConcept, string query, string fields = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(conceptType))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(conceptType)} when calling {nameof(GetConcepts)}");

            if (string.IsNullOrWhiteSpace(specificConcept))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(specificConcept)} when calling {nameof(GetConcepts)}");

            if (string.IsNullOrWhiteSpace(query))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(query)} when calling {nameof(GetConcepts)}");

            var pathParamDictionary = new Dictionary<string, object>
            {
                { "concept-type", conceptType },
                { "specific-concept", specificConcept }
            };

            var queryParamDictionary = new Dictionary<string, object>
            {
                { "fields", fields },
                { "query", query }
            };

            ClientUtils.AddRequestParams(RequestOptions, pathParamDictionary, true);
            ClientUtils.AddRequestParams(RequestOptions, queryParamDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/name/{concept-type}/{specific-concept}.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<Concept>>();

            var exception = ExceptionFactory?.Invoke(nameof(GetConcepts), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }

        /// <summary>
        ///  Searches for concept.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="query">Precedes the search term string. Used in a Search Query. Except for &amp;lt;specific_concept_name&amp;gt;, Search Query will take the required parameters listed above (&amp;lt;concept_type&amp;gt;, &amp;lt;concept_uri&amp;gt;, &amp;lt;article_uri&amp;gt;) as an optional_parameter in addition to the query&#x3D;&amp;lt;query_term&amp;gt;.</param>
        /// <param name="offset">Integer value for the index count from the first concept to the last concept, sorted alphabetically. Used in a Search Query. A Search Query will return up to 10 concepts in its results. (optional, default to 10)</param>
        /// /// <param name="fields">\&quot;all\&quot; or comma-separated list of specific optional fields: pages, ticker_symbol, links, taxonomy, combinations, geocodes, article_list, scope_notes, search_api_query  Optional fields are returned in result_set. They are briefly explained here:  pages: A list of topic pages associated with a specific concept. ticker_symbol: If this concept is a publicly traded company, this field contains the ticker symbol.
        /// links: A list of links from this concept to external data resources. 
        /// taxonomy: For descriptor concepts, this field returns a list of taxonomic relations to other concepts. 
        /// combinations: For descriptor concepts, this field returns a list of the specific meanings tis concept takes on when combined with other concepts. 
        /// geocodes: For geographic concepts, the full GIS record from geonames. 
        /// article_list: A list of up to 10 articles associated with this concept. 
        /// scope_notes: Scope notes contains clarifications and meaning definitions that explicate the relationship between the concept and an article. 
        /// search_api_query: Returns the request one would need to submit to the Article Search API to obtain a list of articles annotated with this concept. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        public async Task<IReadOnlyList<Concept>> SearchConcept(string query, int? offset = default, string fields = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ApiException((int)HttpStatusCode.BadRequest, $"Missing required parameter {nameof(query)} when calling {nameof(SearchConcept)}");
                       
            var queryParamDictionary = new Dictionary<string, object>
            {
                { "fields", fields },
                { "query", query },
                { "offset", offset }
            };

            ClientUtils.AddRequestParams(RequestOptions, queryParamDictionary);

            var wrappedResponse = await this.AsynchronousClient.GetAsync<JObject>(
                    "/search.json", RequestOptions, this.Configuration, cancellationToken)
                .ConfigureAwait(false);

            var result = wrappedResponse.Data
                .SelectToken("results")?
                .ToObject<IReadOnlyList<Concept>>();

            var exception = ExceptionFactory?.Invoke(nameof(SearchConcept), wrappedResponse);
            if (exception != null) throw exception;

            return result;
        }
    }
}
