using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "reviews")]
    public class Review : IEquatable<Review>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Review" /> class.
        /// </summary>
        /// <param name="bookReviewLink">bookReviewLink.</param>
        /// <param name="firstChapterLink">firstChapterLink.</param>
        /// <param name="sundayReviewLink">sundayReviewLink.</param>
        /// <param name="articleChapterLink">articleChapterLink.</param>
        public Review(string bookReviewLink = default, string firstChapterLink = default, string sundayReviewLink = default, string articleChapterLink = default)
        {
            this.BookReviewLink = bookReviewLink;
            this.FirstChapterLink = firstChapterLink;
            this.SundayReviewLink = sundayReviewLink;
            this.ArticleChapterLink = articleChapterLink;
        }

        /// <summary>
        /// Gets or Sets BookReviewLink
        /// </summary>
        [DataMember(Name = "book_review_link", EmitDefaultValue = false)]
        public string BookReviewLink { get; }

        /// <summary>
        /// Gets or Sets FirstChapterLink
        /// </summary>
        [DataMember(Name = "first_chapter_link", EmitDefaultValue = false)]
        public string FirstChapterLink { get; }

        /// <summary>
        /// Gets or Sets SundayReviewLink
        /// </summary>
        [DataMember(Name = "sunday_review_link", EmitDefaultValue = false)]
        public string SundayReviewLink { get; }

        /// <summary>
        /// Gets or Sets ArticleChapterLink
        /// </summary>
        [DataMember(Name = "article_chapter_link", EmitDefaultValue = false)]
        public string ArticleChapterLink { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Reviews {\n");
            sb.Append("  BookReviewLink: ").Append(BookReviewLink).Append('\n');
            sb.Append("  FirstChapterLink: ").Append(FirstChapterLink).Append('\n');
            sb.Append("  SundayReviewLink: ").Append(SundayReviewLink).Append('\n');
            sb.Append("  ArticleChapterLink: ").Append(ArticleChapterLink).Append('\n');
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
            return this.Equals(input as Review);
        }

        /// <summary>
        /// Returns true if Reviews instances are equal
        /// </summary>
        /// <param name="input">Instance of Reviews to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Review input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BookReviewLink == input.BookReviewLink ||
                    (this.BookReviewLink != null &&
                    this.BookReviewLink.Equals(input.BookReviewLink))
                ) && 
                (
                    this.FirstChapterLink == input.FirstChapterLink ||
                    (this.FirstChapterLink != null &&
                    this.FirstChapterLink.Equals(input.FirstChapterLink))
                ) && 
                (
                    this.SundayReviewLink == input.SundayReviewLink ||
                    (this.SundayReviewLink != null &&
                    this.SundayReviewLink.Equals(input.SundayReviewLink))
                ) && 
                (
                    this.ArticleChapterLink == input.ArticleChapterLink ||
                    (this.ArticleChapterLink != null &&
                    this.ArticleChapterLink.Equals(input.ArticleChapterLink))
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
                if (this.BookReviewLink != null)
                    hashCode = hashCode * 59 + this.BookReviewLink.GetHashCode();
                if (this.FirstChapterLink != null)
                    hashCode = hashCode * 59 + this.FirstChapterLink.GetHashCode();
                if (this.SundayReviewLink != null)
                    hashCode = hashCode * 59 + this.SundayReviewLink.GetHashCode();
                if (this.ArticleChapterLink != null)
                    hashCode = hashCode * 59 + this.ArticleChapterLink.GetHashCode();
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