using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "article_list")]
    public class ConceptArticleListWrapper : IEquatable<ConceptArticleListWrapper>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptArticleListWrapper" /> class.
        /// </summary>
        /// <param name="articles">results.</param>
        /// <param name="total">total.</param>
        public ConceptArticleListWrapper(List<ConceptArticle> articles = default, int total = default(int))
        {
            this.Articles = articles;
            this.Total = total;
        }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<ConceptArticle> Articles { get; set; }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptArticleListWrapper {\n");
            sb.Append("  Results: ").Append(Articles).Append('\n');
            sb.Append("  Total: ").Append(Total).Append('\n');
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
            return this.Equals(input as ConceptArticleListWrapper);
        }

        /// <summary>
        /// Returns true if ConceptArticleListWrapper instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptArticleListWrapper to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptArticleListWrapper input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Articles == input.Articles ||
                    this.Articles != null &&
                    input.Articles != null &&
                    this.Articles.SequenceEqual(input.Articles)
                ) &&
                (
                    this.Total == input.Total ||
                    this.Total.Equals(input.Total)
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
                if (this.Articles != null)
                    hashCode = hashCode * 59 + this.Articles.GetHashCode();
                hashCode = hashCode * 59 + this.Total.GetHashCode();
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