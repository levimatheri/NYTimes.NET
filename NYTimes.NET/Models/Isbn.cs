using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Isbns
    /// </summary>
    public class Isbn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Isbn" /> class.
        /// </summary>
        /// <param name="isbn10">isbn10.</param>
        /// <param name="isbn13">isbn13.</param>
        public Isbn(string isbn10 = default, string isbn13 = default)
        {
            this.Isbn10 = isbn10;
            this.Isbn13 = isbn13;
        }

        /// <summary>
        /// Gets or Sets Isbn10
        /// </summary>
        [DataMember(Name = "isbn10", EmitDefaultValue = false)]
        public string Isbn10 { get; }

        /// <summary>
        /// Gets or Sets Isbn13
        /// </summary>
        [DataMember(Name = "isbn13", EmitDefaultValue = false)]
        public string Isbn13 { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Isbns {\n");
            sb.Append("  Isbn10: ").Append(Isbn10).Append('\n');
            sb.Append("  Isbn13: ").Append(Isbn13).Append('\n');
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
            return this.Equals(input as Isbn);
        }

        /// <summary>
        /// Returns true if Isbns instances are equal
        /// </summary>
        /// <param name="input">Instance of Isbns to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Isbn input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Isbn10 == input.Isbn10 ||
                    (this.Isbn10 != null &&
                    this.Isbn10.Equals(input.Isbn10))
                ) && 
                (
                    this.Isbn13 == input.Isbn13 ||
                    (this.Isbn13 != null &&
                    this.Isbn13.Equals(input.Isbn13))
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
                if (this.Isbn10 != null)
                    hashCode = hashCode * 59 + this.Isbn10.GetHashCode();
                if (this.Isbn13 != null)
                    hashCode = hashCode * 59 + this.Isbn13.GetHashCode();
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