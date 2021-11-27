using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "reviews")]
    public class Review : ModelBase
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
    }
}