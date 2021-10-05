using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NYTimes.NET.Models;

namespace NYTimes.NET.Clients.ArticleSearch
{
    /// <summary>
    /// A client for The Article Search API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.nytimes.com/docs/articlesearch-product/1/overview">Article Search API documentation</a> for more information.
    /// </remarks>
    public interface IArticleSearchClient : IApiAccessor
    {
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
        Task<IReadOnlyList<Article>> SearchArticles(string beginDate, string endDate,
            string facet, string facetFields, string facetFilter, string fl, string fq,
            int? page, string q, string sort, CancellationToken cancellationToken);
    }
}