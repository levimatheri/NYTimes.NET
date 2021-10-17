using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BestSellerOverview : IEquatable<BestSellerOverview>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerOverview" /> class.
        /// </summary>
        /// <param name="bestsellersDate">bestsellersDate.</param>
        /// <param name="publishedDate">publishedDate.</param>
        /// <param name="lists">lists.</param>
        public BestSellerOverview(string bestsellersDate = default, string publishedDate = default, List<BestSellerListName> lists = default)
        {
            this.BestsellersDate = bestsellersDate;
            this.PublishedDate = publishedDate;
            this.Lists = lists;
        }

        /// <summary>
        /// Gets or Sets BestsellersDate
        /// </summary>
        [DataMember(Name = "bestsellers_date", EmitDefaultValue = false)]
        public string BestsellersDate { get; }

        /// <summary>
        /// Gets or Sets PublishedDate
        /// </summary>
        [DataMember(Name = "published_date", EmitDefaultValue = false)]
        public string PublishedDate { get; }

        /// <summary>
        /// Gets or Sets Lists
        /// </summary>
        [DataMember(Name = "lists", EmitDefaultValue = false)]
        public List<BestSellerListName> Lists { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse2002Results {\n");
            sb.Append("  BestsellersDate: ").Append(BestsellersDate).Append('\n');
            sb.Append("  PublishedDate: ").Append(PublishedDate).Append('\n');
            sb.Append("  Lists: ").Append(Lists).Append('\n');
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
            return this.Equals(input as BestSellerOverview);
        }

        /// <summary>
        /// Returns true if InlineResponse2002Results instances are equal
        /// </summary>
        /// <param name="input">Instance of InlineResponse2002Results to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BestSellerOverview input)
        {
            if (input == null)
                return false;

            return 
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
                    this.Lists == input.Lists ||
                    this.Lists != null &&
                    input.Lists != null &&
                    this.Lists.SequenceEqual(input.Lists)
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
                if (this.BestsellersDate != null)
                    hashCode = hashCode * 59 + this.BestsellersDate.GetHashCode();
                if (this.PublishedDate != null)
                    hashCode = hashCode * 59 + this.PublishedDate.GetHashCode();
                if (this.Lists != null)
                    hashCode = hashCode * 59 + this.Lists.GetHashCode();
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