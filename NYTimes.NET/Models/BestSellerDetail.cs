using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BestSellerDetail : BestSellerOverview
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerDetail" /> class.
        /// </summary>
        /// <param name="listName">listName.</param>
        /// <param name="bestsellersDate">bestsellersDate.</param>
        /// <param name="publishedDate">publishedDate.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="normalListEndsAt">normalListEndsAt.</param>
        /// <param name="updated">updated.</param>
        /// <param name="books">books.</param>
        /// <param name="corrections">corrections.</param>
        public BestSellerDetail(string listName = default, string bestsellersDate = default, string publishedDate = default, 
            string displayName = default, int normalListEndsAt = default, string updated = default, List<BestSellerBook> books = default, List<object> corrections = default) 
            : base(bestsellersDate, publishedDate)
        {
            this.ListName = listName;
            this.DisplayName = displayName;
            this.NormalListEndsAt = normalListEndsAt;
            this.Updated = updated;
            this.Books = books;
            this.Corrections = corrections;
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
        /// Gets or Sets NormalListEndsAt
        /// </summary>
        [DataMember(Name = "normal_list_ends_at", EmitDefaultValue = false)]
        public int NormalListEndsAt { get; }

        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public string Updated { get; }

        /// <summary>
        /// Gets or Sets Books
        /// </summary>
        [DataMember(Name = "books", EmitDefaultValue = false)]
        public List<BestSellerBook> Books { get; }

        /// <summary>
        /// Gets or Sets Corrections
        /// </summary>
        [DataMember(Name = "corrections", EmitDefaultValue = false)]
        public List<object> Corrections { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BestSellerBook {\n");
            sb.Append("  ListName: ").Append(ListName).Append('\n');
            sb.Append("  BestsellersDate: ").Append(BestsellersDate).Append('\n');
            sb.Append("  PublishedDate: ").Append(PublishedDate).Append('\n');
            sb.Append("  DisplayName: ").Append(DisplayName).Append('\n');
            sb.Append("  NormalListEndsAt: ").Append(NormalListEndsAt).Append('\n');
            sb.Append("  Updated: ").Append(Updated).Append('\n');
            sb.Append("  Books: ").Append(Books).Append('\n');
            sb.Append("  Corrections: ").Append(Corrections).Append('\n');
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
            return this.Equals(input as BestSellerDetail);
        }

        /// <summary>
        /// Returns true if BestSellerBook instances are equal
        /// </summary>
        /// <param name="input">Instance of BestSellerBook to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BestSellerDetail input)
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
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.NormalListEndsAt == input.NormalListEndsAt ||
                    this.NormalListEndsAt.Equals(input.NormalListEndsAt)
                ) && 
                (
                    this.Updated == input.Updated ||
                    (this.Updated != null &&
                    this.Updated.Equals(input.Updated))
                ) && 
                (
                    this.Books == input.Books ||
                    this.Books != null &&
                    input.Books != null &&
                    this.Books.SequenceEqual(input.Books)
                ) && 
                (
                    this.Corrections == input.Corrections ||
                    this.Corrections != null &&
                    input.Corrections != null &&
                    this.Corrections.SequenceEqual(input.Corrections)
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
                if (this.BestsellersDate != null)
                    hashCode = hashCode * 59 + this.BestsellersDate.GetHashCode();
                if (this.PublishedDate != null)
                    hashCode = hashCode * 59 + this.PublishedDate.GetHashCode();
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                hashCode = hashCode * 59 + this.NormalListEndsAt.GetHashCode();
                if (this.Updated != null)
                    hashCode = hashCode * 59 + this.Updated.GetHashCode();
                if (this.Books != null)
                    hashCode = hashCode * 59 + this.Books.GetHashCode();
                if (this.Corrections != null)
                    hashCode = hashCode * 59 + this.Corrections.GetHashCode();
                return hashCode;
            }
        }
    }
}