using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    public class BestSellerBook : Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerBook" /> class.
        /// </summary>
        /// <param name="rank">rank.</param>
        /// <param name="rankLastWeek">rankLastWeek.</param>
        /// <param name="weeksOnList">weeksOnList.</param>
        /// <param name="asterisk">asterisk.</param>
        /// <param name="dagger">dagger.</param>
        /// <param name="primaryIsbn10">primaryIsbn10.</param>
        /// <param name="primaryIsbn13">primaryIsbn13.</param>
        /// <param name="publisher">publisher.</param>
        /// <param name="description">description.</param>
        /// <param name="price">price.</param>
        /// <param name="title">title.</param>
        /// <param name="author">author.</param>
        /// <param name="contributor">contributor.</param>
        /// <param name="contributorNote">contributorNote.</param>
        /// <param name="bookImage">bookImage.</param>
        /// <param name="amazonProductUrl">amazonProductUrl.</param>
        /// <param name="ageGroup">ageGroup.</param>
        /// <param name="bookReviewLink">bookReviewLink.</param>
        /// <param name="firstChapterLink">firstChapterLink.</param>
        /// <param name="sundayReviewLink">sundayReviewLink.</param>
        /// <param name="articleChapterLink">articleChapterLink.</param>
        /// <param name="isbns">isbns.</param>
        /// <param name="reviews">reviews</param>
        public BestSellerBook(int rank = default, int rankLastWeek = default, int weeksOnList = default, 
            int asterisk = default, int dagger = default, string primaryIsbn10 = default, string primaryIsbn13 = default, 
            string publisher = default, string description = default, decimal price = default, string title = default, string author = default,
            string contributor = default, string contributorNote = default, string bookImage = default, string amazonProductUrl = default,
            string ageGroup = default, string bookReviewLink = default, string firstChapterLink = default, string sundayReviewLink = default,
            string articleChapterLink = default, List<Isbn> isbns = default, List<Review> reviews = default)
            : base(rank: rank, rankLastWeek: rankLastWeek, weeksOnList: weeksOnList, asterisk: asterisk, dagger: dagger, isbns: isbns, 
                amazonProductUrl: amazonProductUrl, reviews: reviews)
        {
            this.PrimaryIsbn10 = primaryIsbn10;
            this.PrimaryIsbn13 = primaryIsbn13;
            this.Publisher = publisher;
            this.Description = description;
            this.Price = price;
            this.Title = title;
            this.Author = author;
            this.Contributor = contributor;
            this.ContributorNote = contributorNote;
            this.BookImage = bookImage;
            this.AgeGroup = ageGroup;
            this.BookReviewLink = bookReviewLink;
            this.FirstChapterLink = firstChapterLink;
            this.SundayReviewLink = sundayReviewLink;
            this.ArticleChapterLink = articleChapterLink;
        }

        /// <summary>
        /// Gets or Sets PrimaryIsbn10
        /// </summary>
        [DataMember(Name = "primary_isbn10", EmitDefaultValue = false)]
        public string PrimaryIsbn10 { get; }

        /// <summary>
        /// Gets or Sets PrimaryIsbn13
        /// </summary>
        [DataMember(Name = "primary_isbn13", EmitDefaultValue = false)]
        public string PrimaryIsbn13 { get; }

        /// <summary>
        /// Gets or Sets Publisher
        /// </summary>
        [DataMember(Name = "publisher", EmitDefaultValue = false)]
        public string Publisher { get; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal Price { get; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; }

        /// <summary>
        /// Gets or Sets Author
        /// </summary>
        [DataMember(Name = "author", EmitDefaultValue = false)]
        public string Author { get; }

        /// <summary>
        /// Gets or Sets Contributor
        /// </summary>
        [DataMember(Name = "contributor", EmitDefaultValue = false)]
        public string Contributor { get; }

        /// <summary>
        /// Gets or Sets ContributorNote
        /// </summary>
        [DataMember(Name = "contributor_note", EmitDefaultValue = false)]
        public string ContributorNote { get; }

        /// <summary>
        /// Gets or Sets BookImage
        /// </summary>
        [DataMember(Name = "book_image", EmitDefaultValue = false)]
        public string BookImage { get; }

        /// <summary>
        /// Gets or Sets AgeGroup
        /// </summary>
        [DataMember(Name = "age_group", EmitDefaultValue = false)]
        public string AgeGroup { get; }

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