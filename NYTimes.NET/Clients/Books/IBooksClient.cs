using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NYTimes.NET.Models;

namespace NYTimes.NET.Clients.Books
{
    /// <summary>
    /// A client for The Books API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.nytimes.com/docs/books-product/1/overview">Books API documentation</a> for more information.
    /// </remarks>
    public interface IBooksClient : IApiAccessor
    {
        /// <summary>
        /// Get Best Sellers list.  If no date is provided returns the latest list.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="list">The name of the Times best sellers list (hardcover-fiction, paperback-nonfiction, ...).
        /// The /lists/names service returns all the list names. The encoded list names are lower case with hyphens instead of spaces (e.g. e-book-fiction, instead of E-Book Fiction).</param>
        /// <param name="bestsellersDate">YYYY-MM-DD  The week-ending date for the sales reflected on list-name. Times best sellers lists are compiled using available book sale data.
        /// The bestsellers-date may be significantly earlier than published-date. For additional information, see the explanation at the bottom of any best-seller list page on NYTimes.com
        /// (example: Hardcover Fiction, published Dec. 5 but reflecting sales to Nov. 29). (optional)</param>
        /// <param name="publishedDate">YYYY-MM-DD  The date the best sellers list was published on NYTimes.com (different than bestsellers-date).  Use \&quot;current\&quot; for latest list. (optional)</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate through books if list has more than 20. Defaults to 0.  The num_results field indicates how many books are in the list. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List of <see cref="Book"/>s</returns>
        Task<IReadOnlyList<Book>> GetBestSellersList(string list, string bestsellersDate,
            string publishedDate, int? offset, CancellationToken cancellationToken);

        /// <summary>
        /// Get Best Sellers list names.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of list of <see cref="BestSellerListName"/></returns>
        Task<IReadOnlyList<BestSellerListName>> GetBestSellerListNames(CancellationToken cancellationToken);
    }
}