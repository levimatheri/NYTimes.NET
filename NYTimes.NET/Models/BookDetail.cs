using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// BookDetails
    /// </summary>
    public class BookDetail : IEquatable<BookDetail>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookDetail" /> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="contributor">contributor.</param>
        /// <param name="author">author.</param>
        /// <param name="contributorNote">contributorNote.</param>
        /// <param name="price">price.</param>
        /// <param name="ageGroup">ageGroup.</param>
        /// <param name="publisher">publisher.</param>
        /// <param name="primaryIsbn13">primaryIsbn13.</param>
        /// <param name="primaryIsbn10">primaryIsbn10.</param>
        public BookDetail(string title = default, string description = default, string contributor = default,
            string author = default, string contributorNote = default, decimal price = default, string ageGroup = default,
            string publisher = default, string primaryIsbn13 = default, string primaryIsbn10 = default)
        {
            this.Title = title;
            this.Description = description;
            this.Contributor = contributor;
            this.Author = author;
            this.ContributorNote = contributorNote;
            this.Price = price;
            this.AgeGroup = ageGroup;
            this.Publisher = publisher;
            this.PrimaryIsbn13 = primaryIsbn13;
            this.PrimaryIsbn10 = primaryIsbn10;
        }
        
        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; }

        /// <summary>
        /// Gets or Sets Contributor
        /// </summary>
        [DataMember(Name = "contributor", EmitDefaultValue = false)]
        public string Contributor { get; }

        /// <summary>
        /// Gets or Sets Author
        /// </summary>
        [DataMember(Name = "author", EmitDefaultValue = false)]
        public string Author { get; }

        /// <summary>
        /// Gets or Sets ContributorNote
        /// </summary>
        [DataMember(Name = "contributor_note", EmitDefaultValue = false)]
        public string ContributorNote { get; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal Price { get; }

        /// <summary>
        /// Gets or Sets AgeGroup
        /// </summary>
        [DataMember(Name = "age_group", EmitDefaultValue = false)]
        public string AgeGroup { get; }

        /// <summary>
        /// Gets or Sets Publisher
        /// </summary>
        [DataMember(Name = "publisher", EmitDefaultValue = false)]
        public string Publisher { get; }

        /// <summary>
        /// Gets or Sets PrimaryIsbn13
        /// </summary>
        [DataMember(Name = "primary_isbn13", EmitDefaultValue = false)]
        public string PrimaryIsbn13 { get; }

        /// <summary>
        /// Gets or Sets PrimaryIsbn10
        /// </summary>
        [DataMember(Name = "primary_isbn10", EmitDefaultValue = false)]
        public string PrimaryIsbn10 { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BookDetails {\n");
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Contributor: ").Append(Contributor).Append('\n');
            sb.Append("  Author: ").Append(Author).Append('\n');
            sb.Append("  ContributorNote: ").Append(ContributorNote).Append('\n');
            sb.Append("  Price: ").Append(Price).Append('\n');
            sb.Append("  AgeGroup: ").Append(AgeGroup).Append('\n');
            sb.Append("  Publisher: ").Append(Publisher).Append('\n');
            sb.Append("  PrimaryIsbn13: ").Append(PrimaryIsbn13).Append('\n');
            sb.Append("  PrimaryIsbn10: ").Append(PrimaryIsbn10).Append('\n');
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
            return this.Equals(input as BookDetail);
        }

        /// <summary>
        /// Returns true if BookDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of BookDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BookDetail input)
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
                    this.PrimaryIsbn13 == input.PrimaryIsbn13 ||
                    (this.PrimaryIsbn13 != null &&
                    this.PrimaryIsbn13.Equals(input.PrimaryIsbn13))
                ) && 
                (
                    this.PrimaryIsbn10 == input.PrimaryIsbn10 ||
                    (this.PrimaryIsbn10 != null &&
                    this.PrimaryIsbn10.Equals(input.PrimaryIsbn10))
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
                if (this.PrimaryIsbn13 != null)
                    hashCode = hashCode * 59 + this.PrimaryIsbn13.GetHashCode();
                if (this.PrimaryIsbn10 != null)
                    hashCode = hashCode * 59 + this.PrimaryIsbn10.GetHashCode();
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