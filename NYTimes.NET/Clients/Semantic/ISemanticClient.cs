using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Clients.Semantic
{
    public interface ISemanticClient
    {
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
        /// <returns>Task of list of concepts</returns>
        Task<IReadOnlyList<Concept>> GetConcepts(string conceptType, string specificConcept, string query, string fields = default, CancellationToken cancellationToken = default);

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
        Task<IReadOnlyList<Concept>> SearchConcept(string query, int? offset = default, string fields = default, CancellationToken cancellationToken = default);
    }
}
