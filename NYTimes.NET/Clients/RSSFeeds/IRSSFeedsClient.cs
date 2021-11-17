using NYTimes.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NYTimes.NET.Clients.RSSFeeds
{
    public interface IRSSFeedsClient
    {
        /// <summary>
        /// Returns a list of articles for a given section. Given section name, return lists of articles ranked on the section front. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="section">Section name (Arts, Africa, Americas, ...).</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of channel articles</returns>
        Task<Channel> GetChannelArticles(string section, CancellationToken cancellationToken = default);
    }
}
