using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Book
    /// </summary>
    [DataContract(Name = "results")]
    public class Book : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book" /> class.
        /// </summary>
        /// <param name="listName">listName.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="bestsellersDate">bestsellersDate.</param>
        /// <param name="publishedDate">publishedDate.</param>
        /// <param name="rank">rank.</param>
        /// <param name="rankLastWeek">rankLastWeek.</param>
        /// <param name="weeksOnList">weeksOnList.</param>
        /// <param name="asterisk">asterisk.</param>
        /// <param name="dagger">dagger.</param>
        /// <param name="amazonProductUrl">amazonProductUrl.</param>
        /// <param name="isbns">isbns.</param>
        /// <param name="bookDetails">bookDetails.</param>
        /// <param name="reviews">reviews.</param>
        public Book(string listName = default, string displayName = default, string bestsellersDate = default, string publishedDate = default, 
            int rank = default, int rankLastWeek = default, int weeksOnList = default, int asterisk = default, int dagger = default, 
            string amazonProductUrl = default, List<Isbn> isbns = default, 
            List<BookDetail> bookDetails = default, List<Review> reviews = default)
        {
            this.ListName = listName;
            this.DisplayName = displayName;
            this.BestsellersDate = bestsellersDate;
            this.PublishedDate = publishedDate;
            this.Rank = rank;
            this.RankLastWeek = rankLastWeek;
            this.WeeksOnList = weeksOnList;
            this.Asterisk = asterisk;
            this.Dagger = dagger;
            this.AmazonProductUrl = amazonProductUrl;
            this.Isbns = isbns;
            this.BookDetails = bookDetails;
            this.Reviews = reviews;
        }
        
        /// <summary>
        /// Gets or Sets ListName
        /// </summary>
        [DataMember(Name = "list_name", EmitDefaultValue = false)]
        public string ListName { get; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; }

        /// <summary>
        /// Gets or Sets BestsellersDate
        /// </summary>
        [DataMember(Name = "bestsellers_date", EmitDefaultValue = false)]
        public string BestsellersDate { get; }

        /// <summary>
        /// Gets or Sets PublishedDate
        /// </summary>
        [DataMember(Name = "published_date", EmitDefaultValue = false)]
        public string PublishedDate { get; }

        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name = "rank", EmitDefaultValue = false)]
        public int Rank { get; }

        /// <summary>
        /// Gets or Sets RankLastWeek
        /// </summary>
        [DataMember(Name = "rank_last_week", EmitDefaultValue = false)]
        public int RankLastWeek { get; }

        /// <summary>
        /// Gets or Sets WeeksOnList
        /// </summary>
        [DataMember(Name = "weeks_on_list", EmitDefaultValue = false)]
        public int WeeksOnList { get; }

        /// <summary>
        /// Gets or Sets Asterisk
        /// </summary>
        [DataMember(Name = "asterisk", EmitDefaultValue = false)]
        public int Asterisk { get; }

        /// <summary>
        /// Gets or Sets Dagger
        /// </summary>
        [DataMember(Name = "dagger", EmitDefaultValue = false)]
        public int Dagger { get; }

        /// <summary>
        /// Gets or Sets AmazonProductUrl
        /// </summary>
        [DataMember(Name = "amazon_product_url", EmitDefaultValue = false)]
        public string AmazonProductUrl { get; }

        /// <summary>
        /// Gets or Sets Isbns
        /// </summary>
        [DataMember(Name = "isbns", EmitDefaultValue = false)]
        public List<Isbn> Isbns { get; }

        /// <summary>
        /// Gets or Sets BookDetails
        /// </summary>
        [DataMember(Name = "book_details", EmitDefaultValue = false)]
        public List<BookDetail> BookDetails { get; }

        /// <summary>
        /// Gets or Sets Reviews
        /// </summary>
        [DataMember(Name = "reviews", EmitDefaultValue = false)]
        public List<Review> Reviews { get; }
    }
}