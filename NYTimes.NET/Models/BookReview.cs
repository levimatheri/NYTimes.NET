using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BookReview : ModelBase
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
    }
}