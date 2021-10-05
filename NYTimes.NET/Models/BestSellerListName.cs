using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// BestSellerListName
    /// </summary>
    [DataContract(Name = "results")]
    public class BestSellerListName : IEquatable<BestSellerListName>, IValidatableObject
    {
        /// <summary>
        /// Defines Updated
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpdatedEnum
        {
            /// <summary>
            /// Enum WEEKLY for value: WEEKLY
            /// </summary>
            [EnumMember(Value = "WEEKLY")]
            WEEKLY = 1,

            /// <summary>
            /// Enum MONTHLY for value: MONTHLY
            /// </summary>
            [EnumMember(Value = "MONTHLY")]
            MONTHLY = 2
        }


        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public UpdatedEnum? Updated { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerListName" /> class.
        /// </summary>
        /// <param name="listName">listName.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="listNameEncoded">listNameEncoded.</param>
        /// <param name="oldestPublishedDate">oldestPublishedDate.</param>
        /// <param name="newestPublishedDate">newestPublishedDate.</param>
        /// <param name="updated">updated.</param>
        public BestSellerListName(string listName = default, string displayName = default, string listNameEncoded = default,
            string oldestPublishedDate = default, string newestPublishedDate = default, UpdatedEnum? updated = default)
        {
            this.ListName = listName;
            this.DisplayName = displayName;
            this.ListNameEncoded = listNameEncoded;
            this.OldestPublishedDate = oldestPublishedDate;
            this.NewestPublishedDate = newestPublishedDate;
            this.Updated = updated;
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
        /// Gets or Sets ListNameEncoded
        /// </summary>
        [DataMember(Name = "list_name_encoded", EmitDefaultValue = false)]
        public string ListNameEncoded { get; }

        /// <summary>
        /// Gets or Sets OldestPublishedDate
        /// </summary>
        [DataMember(Name = "oldest_published_date", EmitDefaultValue = false)]
        public string OldestPublishedDate { get; }

        /// <summary>
        /// Gets or Sets NewestPublishedDate
        /// </summary>
        [DataMember(Name = "newest_published_date", EmitDefaultValue = false)]
        public string NewestPublishedDate { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BestSellerListName {\n");
            sb.Append("  ListName: ").Append(ListName).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  ListNameEncoded: ").Append(ListNameEncoded).Append("\n");
            sb.Append("  OldestPublishedDate: ").Append(OldestPublishedDate).Append("\n");
            sb.Append("  NewestPublishedDate: ").Append(NewestPublishedDate).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BestSellerListName);
        }

        /// <summary>
        /// Returns true if BestSellerListName instances are equal
        /// </summary>
        /// <param name="input">Instance of BestSellerListName to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BestSellerListName input)
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
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) && 
                (
                    this.ListNameEncoded == input.ListNameEncoded ||
                    (this.ListNameEncoded != null &&
                    this.ListNameEncoded.Equals(input.ListNameEncoded))
                ) && 
                (
                    this.OldestPublishedDate == input.OldestPublishedDate ||
                    (this.OldestPublishedDate != null &&
                    this.OldestPublishedDate.Equals(input.OldestPublishedDate))
                ) && 
                (
                    this.NewestPublishedDate == input.NewestPublishedDate ||
                    (this.NewestPublishedDate != null &&
                    this.NewestPublishedDate.Equals(input.NewestPublishedDate))
                ) && 
                (
                    this.Updated == input.Updated ||
                    this.Updated.Equals(input.Updated)
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
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.ListNameEncoded != null)
                    hashCode = hashCode * 59 + this.ListNameEncoded.GetHashCode();
                if (this.OldestPublishedDate != null)
                    hashCode = hashCode * 59 + this.OldestPublishedDate.GetHashCode();
                if (this.NewestPublishedDate != null)
                    hashCode = hashCode * 59 + this.NewestPublishedDate.GetHashCode();
                hashCode = hashCode * 59 + this.Updated.GetHashCode();
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