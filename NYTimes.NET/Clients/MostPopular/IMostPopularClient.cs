using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Clients.MostPopular
{
    public interface IMostPopularClient
    {
        /// <summary>
        /// Gets the most emailed articles on NYTimes.com for specified period of time (1 day, 7 days, or 30 days). 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="period">Time period: 1, 7, or 30 days.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of Articles</returns>
        Task<IReadOnlyList<Article>> GetMostEmailedArticlesByPeriod(int period, CancellationToken cancellationToken = default);
    }
}
