using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BestSellerHistory : BestSellerBook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerHistory" /> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="contributor">contributor.</param>
        /// <param name="author">author.</param>
        /// <param name="contributorNote">contributorNote.</param>
        /// <param name="price">price.</param>
        /// <param name="ageGroup">ageGroup.</param>
        /// <param name="publisher">publisher.</param>
        /// <param name="isbns">isbns.</param>
        /// <param name="ranksHistory">ranksHistory.</param>
        /// <param name="reviews">reviews.</param>
        public BestSellerHistory(string title = default, string description = default, string contributor = default, string author = default, 
            string contributorNote = default, decimal price = default, string ageGroup = default, string publisher = default, List<Isbn> isbns = default,
            List<BestSellerBook> ranksHistory = default, List<Review> reviews = default)
            : base(title: title, description: description, contributor: contributor, author: author, contributorNote: contributorNote,
                price: price, ageGroup: ageGroup, publisher: publisher, isbns: isbns, reviews: reviews)
        {
            this.RanksHistory = ranksHistory;
        }

        /// <summary>
        /// Gets or Sets RanksHistory
        /// </summary>
        [DataMember(Name = "ranks_history", EmitDefaultValue = false)]
        public List<BestSellerBook> RanksHistory { get; }
    }
}