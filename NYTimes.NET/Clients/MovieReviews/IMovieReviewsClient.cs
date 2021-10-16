using NYTimes.NET.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Clients.MovieReviews
{
    public interface IMovieReviewsClient
    {
        /// <summary>
        /// Get movie critics name, bio and image. You can either specify the reviewer name or use \&quot;all\&quot;, \&quot;full-time\&quot;, or \&quot;part-time\&quot;. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="reviewer">Reviewer name or \&quot;all\&quot; for all reviewers, \&quot;full-time\&quot; for full-time reviewers, or \&quot;part-time\&quot; for part-time reviewers.</param>
        /// <returns>Task of list of critics</returns>
        Task<IReadOnlyList<Critic>> GetMovieCritics(string reviewer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get movie reviews.  Can filter to only return Critics&#39; Picks. Supports ordering results by-publication-date or by-opening-date. Use offset to paginate thru results, 20 at a time. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter by critics&#39; pick or not.</param>
        /// <param name="offset">Sets the starting point of the result set.  Needs to be multiple of 20. (optional, default to 0)</param>
        /// <param name="order">How to order the results. (optional)</param>
        /// <returns>Task of list of reviews</returns>
        Task<IReadOnlyList<MovieReview>> GetMovieReviews(string type, int? offset = default, string order = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Search for movie reviews. Supports filtering by Critics&#39; Pick. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="criticsPick">Set to Y to only show critics&#39; picks.  Otherwise shows both. (optional)</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate thru results. Defaults to 0. The has_more field indicates the response has more results. (optional)</param>
        /// <param name="openingDate">U.S. opening date range. Start and end dates separated by colon (e.g. 1930-01-01:1940-01-01). (optional)</param>
        /// <param name="order">Field to order results by (e.g. by-publication-date). (optional)</param>
        /// <param name="publicationDate">Review publication date range. Start and end dates separated by colon (e.g. 1930-01-01:1940-01-01). (optional)</param>
        /// <param name="reviewer">Filter by reviewer byline (e.g. Stephen Holden). (optional)</param>
        /// <param name="query">Search keyword (e.g. lebowski). (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of reviews</returns>
        Task<IReadOnlyList<MovieReview>> SearchMovieReviews(string criticsPick = default, int? offset = default, string openingDate = default, string order = default, string publicationDate = default, string reviewer = default, string query = default, CancellationToken cancellationToken = default);
    }
}
