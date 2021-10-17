using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Book
    /// </summary>
    [DataContract(Name = "results")]
    public class Book : IEquatable<Book>, IValidatableObject
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
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Book {\n");
            sb.Append("  ListName: ").Append(ListName).Append('\n');
            sb.Append("  DisplayName: ").Append(DisplayName).Append('\n');
            sb.Append("  BestsellersDate: ").Append(BestsellersDate).Append('\n');
            sb.Append("  PublishedDate: ").Append(PublishedDate).Append('\n');
            sb.Append("  Rank: ").Append(Rank).Append('\n');
            sb.Append("  RankLastWeek: ").Append(RankLastWeek).Append('\n');
            sb.Append("  WeeksOnList: ").Append(WeeksOnList).Append('\n');
            sb.Append("  Asterisk: ").Append(Asterisk).Append('\n');
            sb.Append("  Dagger: ").Append(Dagger).Append('\n');
            sb.Append("  AmazonProductUrl: ").Append(AmazonProductUrl).Append('\n');
            sb.Append("  Isbns: ").Append(Isbns).Append('\n');
            sb.Append("  BookDetails: ").Append(BookDetails).Append('\n');
            sb.Append("  Reviews: ").Append(Reviews).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }
        
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Book);
        }

        /// <summary>
        /// Returns true if InlineResponse200Results instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse200Results to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Book input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ListName == input.ListName ||
                    (this.ListName != null &&
                    this.ListName.Equals(input.ListName))
                ) && 
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.BestsellersDate == input.BestsellersDate ||
                    (this.BestsellersDate != null &&
                    this.BestsellersDate.Equals(input.BestsellersDate))
                ) && 
                (
                    this.PublishedDate == input.PublishedDate ||
                    (this.PublishedDate != null &&
                    this.PublishedDate.Equals(input.PublishedDate))
                ) && 
                (
                    this.Rank == input.Rank ||
                    this.Rank.Equals(input.Rank)
                ) && 
                (
                    this.RankLastWeek == input.RankLastWeek ||
                    this.RankLastWeek.Equals(input.RankLastWeek)
                ) && 
                (
                    this.WeeksOnList == input.WeeksOnList ||
                    this.WeeksOnList.Equals(input.WeeksOnList)
                ) && 
                (
                    this.Asterisk == input.Asterisk ||
                    this.Asterisk.Equals(input.Asterisk)
                ) && 
                (
                    this.Dagger == input.Dagger ||
                    this.Dagger.Equals(input.Dagger)
                ) && 
                (
                    this.AmazonProductUrl == input.AmazonProductUrl ||
                    (this.AmazonProductUrl != null &&
                    this.AmazonProductUrl.Equals(input.AmazonProductUrl))
                ) && 
                (
                    this.Isbns == input.Isbns ||
                    this.Isbns != null &&
                    input.Isbns != null &&
                    this.Isbns.SequenceEqual(input.Isbns)
                ) && 
                (
                    this.BookDetails == input.BookDetails ||
                    this.BookDetails != null &&
                    input.BookDetails != null &&
                    this.BookDetails.SequenceEqual(input.BookDetails)
                ) && 
                (
                    this.Reviews == input.Reviews ||
                    this.Reviews != null &&
                    input.Reviews != null &&
                    this.Reviews.SequenceEqual(input.Reviews)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (this.ListName != null)
                    hashCode = hashCode * 59 + this.ListName.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.BestsellersDate != null)
                    hashCode = hashCode * 59 + this.BestsellersDate.GetHashCode();
                if (this.PublishedDate != null)
                    hashCode = hashCode * 59 + this.PublishedDate.GetHashCode();
                hashCode = hashCode * 59 + this.Rank.GetHashCode();
                hashCode = hashCode * 59 + this.RankLastWeek.GetHashCode();
                hashCode = hashCode * 59 + this.WeeksOnList.GetHashCode();
                hashCode = hashCode * 59 + this.Asterisk.GetHashCode();
                hashCode = hashCode * 59 + this.Dagger.GetHashCode();
                if (this.AmazonProductUrl != null)
                    hashCode = hashCode * 59 + this.AmazonProductUrl.GetHashCode();
                if (this.Isbns != null)
                    hashCode = hashCode * 59 + this.Isbns.GetHashCode();
                if (this.BookDetails != null)
                    hashCode = hashCode * 59 + this.BookDetails.GetHashCode();
                if (this.Reviews != null)
                    hashCode = hashCode * 59 + this.Reviews.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}