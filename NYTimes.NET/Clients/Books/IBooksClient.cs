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

        /// <summary>
        /// Get top 5 books for all the Best Sellers lists for specified date.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="publishedDate">YYYY-MM-DD  The best-seller list publication date. You do not have to specify the exact date the list was published.
        /// The service will search forward (into the future) for the closest publication date to the date you specify.
        /// For example, a request for lists/overview/2013-05-22 will retrieve the list that was published on 05-26.
        /// If you do not include a published date, the current week&#39;s best sellers lists will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of <see cref="BestSellerOverview"/></returns>
        Task<BestSellerOverview> GetBestSellerOverview(string publishedDate, CancellationToken cancellationToken);

        /// <summary>
        /// Get book reviews.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="isbn">Searching by ISBN is the recommended method. You can enter 10- or 13-digit ISBNs. (optional)</param>
        /// <param name="title">You’ll need to enter the full title of the book. Spaces in the title will be converted into the characters %20. (optional)</param>
        /// <param name="author">You’ll need to enter the author’s first and last name, separated by a space. This space will be converted into the characters %20. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of <see cref="BookReview"/></returns>
        Task<IReadOnlyList<BookReview>> GetBookReviews(long? isbn, string title, string author, CancellationToken cancellationToken);

        /// <summary>
        /// Get Best Sellers list by date.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="date">YYYY-MM-DD or \&quot;current\&quot;  The date the best sellers list was published on NYTimes.com.  Use \&quot;current\&quot; to get latest list.</param>
        /// <param name="list">Name of the Best Sellers List (e.g. hardcover-fiction). You can get the full list of names from the /lists/names.json service.</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate thru books if list has more than 20. Defaults to 0.  The num_results field indicates how many books are in the list. (optional)</param>
        /// <returns>ApiResponse of InlineResponse2001</returns>
        Task<BestSellerOverview> GetBestSellersListByDate(string date, string list, int? offset, CancellationToken cancellationToken);

        /// <summary>
        /// Get Best Sellers list history.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="ageGroup">The target age group for the best seller. (optional)</param>
        /// <param name="author">The author of the best seller. The author field does not include additional contributors (see Data Structure for more details about the author and contributor fields).
        /// When searching the author field, you can specify any combination of first, middle and last names.  When sort-by is set to author, the results will be sorted by author&#39;s first name. (optional)</param>
        /// <param name="contributor">The author of the best seller, as well as other contributors such as the illustrator (to search or sort by author name only, use author instead).
        /// When searching, you can specify any combination of first, middle and last names of any of the contributors.
        /// When sort-by is set to contributor, the results will be sorted by the first name of the first contributor listed. (optional)</param>
        /// <param name="isbn">International Standard Book Number, 10 or 13 digits  A best seller may have both 10-digit and 13-digit ISBNs, and may have multiple ISBNs of each type.
        /// To search on multiple ISBNs, separate the ISBNs with semicolons (example: 9780446579933;0061374229). (optional)</param>
        /// <param name="offset">Sets the starting point of the result set (0, 20, ...).  Used to paginate thru results if there are more than 20. Defaults to 0.
        /// The num_results field indicates how many results there are total. (optional)</param>
        /// <param name="price">The publisher&#39;s list price of the best seller, including decimal point. (optional)</param>
        /// <param name="publisher">The standardized name of the publisher (optional)</param>
        /// <param name="title">The title of the best seller  When searching, you can specify a portion of a title or a full title. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of list of BestSellerHistory </returns>
        Task<IReadOnlyList<BestSellerBook>> GetBestSellersListHistory(string ageGroup, string author, string contributor,
            string isbn, int? offset, string price, string publisher, string title, CancellationToken cancellationToken);
    }
}