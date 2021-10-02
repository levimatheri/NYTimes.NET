using System.Collections.Generic;
using System.Threading.Tasks;
using NYTimes.NET.Models.Archive;

namespace NYTimes.NET.Clients.Archive
{
    /// <summary>
    /// A client for The Archive API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.nytimes.com/docs/archive-product/1/overview">Archive API documentation</a> for more information.
    /// </remarks>
    public interface IArchiveClient : IApiAccessor
    {
        /// <summary>
        /// Returns an array of articles for a given month.
        /// </summary>
        /// <remarks>
        /// Pass in year and month and get back JSON with all articles for that month. The response can be big (~20 megabytes) and contain thousands of articles, depending on the year and month. 
        /// </remarks>
        /// <exception cref="Clients.ApiException">Thrown when fails to make API call</exception>
        /// <param name="year">Year: 1851-2019</param>
        /// <param name="month">Year: 1-12</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of InlineResponse200</returns>
        Task<IReadOnlyList<Article>> GetAllMonthArticles(int year, int month, System.Threading.CancellationToken cancellationToken = default);
    }
}