using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BestSellerHistory : BestSellerBook, IEquatable<BestSellerHistory>, IValidatableObject
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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse2004Results {\n");
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Contributor: ").Append(Contributor).Append('\n');
            sb.Append("  Author: ").Append(Author).Append('\n');
            sb.Append("  ContributorNote: ").Append(ContributorNote).Append('\n');
            sb.Append("  Price: ").Append(Price).Append('\n');
            sb.Append("  AgeGroup: ").Append(AgeGroup).Append('\n');
            sb.Append("  Publisher: ").Append(Publisher).Append('\n');
            sb.Append("  Isbns: ").Append(Isbns).Append('\n');
            sb.Append("  RanksHistory: ").Append(RanksHistory).Append('\n');
            sb.Append("  Reviews: ").Append(Reviews).Append('\n');
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
            return this.Equals(input as BestSellerHistory);
        }

        /// <summary>
        /// Returns true if InlineResponse2004Results instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse2004Results to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BestSellerHistory input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Contributor == input.Contributor ||
                    (this.Contributor != null &&
                    this.Contributor.Equals(input.Contributor))
                ) && 
                (
                    this.Author == input.Author ||
                    (this.Author != null &&
                    this.Author.Equals(input.Author))
                ) && 
                (
                    this.ContributorNote == input.ContributorNote ||
                    (this.ContributorNote != null &&
                    this.ContributorNote.Equals(input.ContributorNote))
                ) && 
                (
                    this.Price == input.Price ||
                    this.Price.Equals(input.Price)
                ) && 
                (
                    this.AgeGroup == input.AgeGroup ||
                    (this.AgeGroup != null &&
                    this.AgeGroup.Equals(input.AgeGroup))
                ) && 
                (
                    this.Publisher == input.Publisher ||
                    (this.Publisher != null &&
                    this.Publisher.Equals(input.Publisher))
                ) && 
                (
                    this.Isbns == input.Isbns ||
                    this.Isbns != null &&
                    input.Isbns != null &&
                    this.Isbns.SequenceEqual(input.Isbns)
                ) && 
                (
                    this.RanksHistory == input.RanksHistory ||
                    this.RanksHistory != null &&
                    input.RanksHistory != null &&
                    this.RanksHistory.SequenceEqual(input.RanksHistory)
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
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Contributor != null)
                    hashCode = hashCode * 59 + this.Contributor.GetHashCode();
                if (this.Author != null)
                    hashCode = hashCode * 59 + this.Author.GetHashCode();
                if (this.ContributorNote != null)
                    hashCode = hashCode * 59 + this.ContributorNote.GetHashCode();
                hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.AgeGroup != null)
                    hashCode = hashCode * 59 + this.AgeGroup.GetHashCode();
                if (this.Publisher != null)
                    hashCode = hashCode * 59 + this.Publisher.GetHashCode();
                if (this.Isbns != null)
                    hashCode = hashCode * 59 + this.Isbns.GetHashCode();
                if (this.RanksHistory != null)
                    hashCode = hashCode * 59 + this.RanksHistory.GetHashCode();
                if (this.Reviews != null)
                    hashCode = hashCode * 59 + this.Reviews.GetHashCode();
                return hashCode;
            }
        }
    }
}