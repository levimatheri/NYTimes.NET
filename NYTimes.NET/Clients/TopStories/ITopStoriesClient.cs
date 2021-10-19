using NYTimes.NET.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Clients.TopStories
{
    public interface ITopStoriesClient
    {
        /// <summary>
        ///  Gets articles currently on the specified section.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="url">The complete URL of a specific news item, URL-encoded or backslash-escaped</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of articles</returns>
        Task<IReadOnlyList<Article>> GetArticlesBySection(string section, CancellationToken cancellationToken = default);
    }
}
