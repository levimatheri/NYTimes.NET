using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BookReview : IEquatable<BookReview>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookReview" /> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="publicationDt">publicationDt.</param>
        /// <param name="byline">byline.</param>
        /// <param name="bookTitle">bookTitle.</param>
        /// <param name="bookAuthor">bookAuthor.</param>
        /// <param name="summary">summary.</param>
        /// <param name="isbn13">isbn13.</param>
        public BookReview(string url = default, string publicationDt = default, string byline = default, string bookTitle = default,
            string bookAuthor = default, string summary = default, List<string> isbn13 = default)
        {
            this.Url = url;
            this.PublicationDt = publicationDt;
            this.Byline = byline;
            this.BookTitle = bookTitle;
            this.BookAuthor = bookAuthor;
            this.Summary = summary;
            this.Isbn13 = isbn13;
        }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; }

        /// <summary>
        /// Gets or Sets PublicationDt
        /// </summary>
        [DataMember(Name = "publication_dt", EmitDefaultValue = false)]
        public string PublicationDt { get; }

        /// <summary>
        /// Gets or Sets Byline
        /// </summary>
        [DataMember(Name = "byline", EmitDefaultValue = false)]
        public string Byline { get; }

        /// <summary>
        /// Gets or Sets BookTitle
        /// </summary>
        [DataMember(Name = "book_title", EmitDefaultValue = false)]
        public string BookTitle { get; }

        /// <summary>
        /// Gets or Sets BookAuthor
        /// </summary>
        [DataMember(Name = "book_author", EmitDefaultValue = false)]
        public string BookAuthor { get; }

        /// <summary>
        /// Gets or Sets Summary
        /// </summary>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        public string Summary { get; }

        /// <summary>
        /// Gets or Sets Isbn13
        /// </summary>
        [DataMember(Name = "isbn13", EmitDefaultValue = false)]
        public List<string> Isbn13 { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BookReview {\n");
            sb.Append("  Url: ").Append(Url).Append('\n');
            sb.Append("  PublicationDt: ").Append(PublicationDt).Append('\n');
            sb.Append("  Byline: ").Append(Byline).Append('\n');
            sb.Append("  BookTitle: ").Append(BookTitle).Append('\n');
            sb.Append("  BookAuthor: ").Append(BookAuthor).Append('\n');
            sb.Append("  Summary: ").Append(Summary).Append('\n');
            sb.Append("  Isbn13: ").Append(Isbn13).Append('\n');
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
            return this.Equals(input as BookReview);
        }

        /// <summary>
        /// Returns true if BookReview instances are equal
        /// </summary>
        /// <param name="input">Instance of BookReview to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BookReview input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.PublicationDt == input.PublicationDt ||
                    (this.PublicationDt != null &&
                    this.PublicationDt.Equals(input.PublicationDt))
                ) && 
                (
                    this.Byline == input.Byline ||
                    (this.Byline != null &&
                    this.Byline.Equals(input.Byline))
                ) && 
                (
                    this.BookTitle == input.BookTitle ||
                    (this.BookTitle != null &&
                    this.BookTitle.Equals(input.BookTitle))
                ) && 
                (
                    this.BookAuthor == input.BookAuthor ||
                    (this.BookAuthor != null &&
                    this.BookAuthor.Equals(input.BookAuthor))
                ) && 
                (
                    this.Summary == input.Summary ||
                    (this.Summary != null &&
                    this.Summary.Equals(input.Summary))
                ) && 
                (
                    this.Isbn13 == input.Isbn13 ||
                    this.Isbn13 != null &&
                    input.Isbn13 != null &&
                    this.Isbn13.SequenceEqual(input.Isbn13)
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
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.PublicationDt != null)
                    hashCode = hashCode * 59 + this.PublicationDt.GetHashCode();
                if (this.Byline != null)
                    hashCode = hashCode * 59 + this.Byline.GetHashCode();
                if (this.BookTitle != null)
                    hashCode = hashCode * 59 + this.BookTitle.GetHashCode();
                if (this.BookAuthor != null)
                    hashCode = hashCode * 59 + this.BookAuthor.GetHashCode();
                if (this.Summary != null)
                    hashCode = hashCode * 59 + this.Summary.GetHashCode();
                if (this.Isbn13 != null)
                    hashCode = hashCode * 59 + this.Isbn13.GetHashCode();
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