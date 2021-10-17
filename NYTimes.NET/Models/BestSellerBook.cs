using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    public class BestSellerBook : Book, IEquatable<Book>, IValidatableObject
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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BestSellerBook {\n");
            sb.Append("  Rank: ").Append(Rank).Append('\n');
            sb.Append("  RankLastWeek: ").Append(RankLastWeek).Append('\n');
            sb.Append("  WeeksOnList: ").Append(WeeksOnList).Append('\n');
            sb.Append("  Asterisk: ").Append(Asterisk).Append('\n');
            sb.Append("  Dagger: ").Append(Dagger).Append('\n');
            sb.Append("  PrimaryIsbn10: ").Append(PrimaryIsbn10).Append('\n');
            sb.Append("  PrimaryIsbn13: ").Append(PrimaryIsbn13).Append('\n');
            sb.Append("  Publisher: ").Append(Publisher).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Price: ").Append(Price).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  Author: ").Append(Author).Append('\n');
            sb.Append("  Contributor: ").Append(Contributor).Append('\n');
            sb.Append("  ContributorNote: ").Append(ContributorNote).Append('\n');
            sb.Append("  BookImage: ").Append(BookImage).Append('\n');
            sb.Append("  AmazonProductUrl: ").Append(AmazonProductUrl).Append('\n');
            sb.Append("  AgeGroup: ").Append(AgeGroup).Append('\n');
            sb.Append("  BookReviewLink: ").Append(BookReviewLink).Append('\n');
            sb.Append("  FirstChapterLink: ").Append(FirstChapterLink).Append('\n');
            sb.Append("  SundayReviewLink: ").Append(SundayReviewLink).Append('\n');
            sb.Append("  ArticleChapterLink: ").Append(ArticleChapterLink).Append('\n');
            sb.Append("  Isbns: ").Append(Isbns).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BestSellerBook);
        }

        /// <summary>
        /// Returns true if BestSellerBook instances are equal
        /// </summary>
        /// <param name="input">Instance of BestSellerBook to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BestSellerBook input)
        {
            if (input == null)
                return false;

            return 
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
                    this.PrimaryIsbn10 == input.PrimaryIsbn10 ||
                    (this.PrimaryIsbn10 != null &&
                    this.PrimaryIsbn10.Equals(input.PrimaryIsbn10))
                ) && 
                (
                    this.PrimaryIsbn13 == input.PrimaryIsbn13 ||
                    (this.PrimaryIsbn13 != null &&
                    this.PrimaryIsbn13.Equals(input.PrimaryIsbn13))
                ) && 
                (
                    this.Publisher == input.Publisher ||
                    (this.Publisher != null &&
                    this.Publisher.Equals(input.Publisher))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Price == input.Price ||
                    this.Price.Equals(input.Price)
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Author == input.Author ||
                    (this.Author != null &&
                    this.Author.Equals(input.Author))
                ) && 
                (
                    this.Contributor == input.Contributor ||
                    (this.Contributor != null &&
                    this.Contributor.Equals(input.Contributor))
                ) && 
                (
                    this.ContributorNote == input.ContributorNote ||
                    (this.ContributorNote != null &&
                    this.ContributorNote.Equals(input.ContributorNote))
                ) && 
                (
                    this.BookImage == input.BookImage ||
                    (this.BookImage != null &&
                    this.BookImage.Equals(input.BookImage))
                ) && 
                (
                    this.AmazonProductUrl == input.AmazonProductUrl ||
                    (this.AmazonProductUrl != null &&
                    this.AmazonProductUrl.Equals(input.AmazonProductUrl))
                ) && 
                (
                    this.AgeGroup == input.AgeGroup ||
                    (this.AgeGroup != null &&
                    this.AgeGroup.Equals(input.AgeGroup))
                ) && 
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
                ) && 
                (
                    this.Isbns == input.Isbns ||
                    this.Isbns != null &&
                    input.Isbns != null &&
                    this.Isbns.SequenceEqual(input.Isbns)
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
                hashCode = hashCode * 59 + this.Rank.GetHashCode();
                hashCode = hashCode * 59 + this.RankLastWeek.GetHashCode();
                hashCode = hashCode * 59 + this.WeeksOnList.GetHashCode();
                hashCode = hashCode * 59 + this.Asterisk.GetHashCode();
                hashCode = hashCode * 59 + this.Dagger.GetHashCode();
                if (this.PrimaryIsbn10 != null)
                    hashCode = hashCode * 59 + this.PrimaryIsbn10.GetHashCode();
                if (this.PrimaryIsbn13 != null)
                    hashCode = hashCode * 59 + this.PrimaryIsbn13.GetHashCode();
                if (this.Publisher != null)
                    hashCode = hashCode * 59 + this.Publisher.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Author != null)
                    hashCode = hashCode * 59 + this.Author.GetHashCode();
                if (this.Contributor != null)
                    hashCode = hashCode * 59 + this.Contributor.GetHashCode();
                if (this.ContributorNote != null)
                    hashCode = hashCode * 59 + this.ContributorNote.GetHashCode();
                if (this.BookImage != null)
                    hashCode = hashCode * 59 + this.BookImage.GetHashCode();
                if (this.AmazonProductUrl != null)
                    hashCode = hashCode * 59 + this.AmazonProductUrl.GetHashCode();
                if (this.AgeGroup != null)
                    hashCode = hashCode * 59 + this.AgeGroup.GetHashCode();
                if (this.BookReviewLink != null)
                    hashCode = hashCode * 59 + this.BookReviewLink.GetHashCode();
                if (this.FirstChapterLink != null)
                    hashCode = hashCode * 59 + this.FirstChapterLink.GetHashCode();
                if (this.SundayReviewLink != null)
                    hashCode = hashCode * 59 + this.SundayReviewLink.GetHashCode();
                if (this.ArticleChapterLink != null)
                    hashCode = hashCode * 59 + this.ArticleChapterLink.GetHashCode();
                if (this.Isbns != null)
                    hashCode = hashCode * 59 + this.Isbns.GetHashCode();
                return hashCode;
            }
        }
    }
}