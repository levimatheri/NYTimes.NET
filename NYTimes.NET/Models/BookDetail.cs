using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// BookDetails
    /// </summary>
    public class BookDetail : ModelBase
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
    }
}