using NYTimes.NET.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Clients.TimesNewsWire
{
    public interface ITimesNewsWireClient
    {
        /// <summary>
        ///  Get content.
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="url">The complete URL of a specific news item, URL-encoded or backslash-escaped</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of content</returns>
        Task<IReadOnlyList<Article>> GetContent(string url, CancellationToken cancellationToken = default);

        /// <summary>
        ///  Get content section list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of content</returns>
        Task<IReadOnlyList<Section>> GetContentSectionList(CancellationToken cancellationToken = default);

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
        Task<IReadOnlyList<Article>> GetContentBySourceAndSection(string source, string section, int? limit = default, int? offset = default, CancellationToken cancellationToken = default);
    }
}
