using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "concepts")]
    public class ConceptArticleListConcepts : IEquatable<ConceptArticleListConcepts>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptArticleListConcepts" /> class.
        /// </summary>
        /// <param name="nytdDes">nytdDes.</param>
        /// <param name="nytdOrg">nytdOrg.</param>
        /// <param name="nytdPer">nytdPer.</param>
        public ConceptArticleListConcepts(List<string> nytdDes = default, List<string> nytdOrg = default, List<string> nytdPer = default)
        {
            this.NytdDes = nytdDes;
            this.NytdOrg = nytdOrg;
            this.NytdPer = nytdPer;
        }

        /// <summary>
        /// Gets or Sets NytdDes
        /// </summary>
        [DataMember(Name = "nytd_des", EmitDefaultValue = false)]
        public List<string> NytdDes { get; set; }

        /// <summary>
        /// Gets or Sets NytdOrg
        /// </summary>
        [DataMember(Name = "nytd_org", EmitDefaultValue = false)]
        public List<string> NytdOrg { get; set; }

        /// <summary>
        /// Gets or Sets NytdPer
        /// </summary>
        [DataMember(Name = "nytd_per", EmitDefaultValue = false)]
        public List<string> NytdPer { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptArticleListConcepts {\n");
            sb.Append("  NytdDes: ").Append(NytdDes).Append('\n');
            sb.Append("  NytdOrg: ").Append(NytdOrg).Append('\n');
            sb.Append("  NytdPer: ").Append(NytdPer).Append('\n');
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
            return this.Equals(input as ConceptArticleListConcepts);
        }

        /// <summary>
        /// Returns true if ConceptArticleListConcepts instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptArticleListConcepts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptArticleListConcepts input)
        {
            if (input == null)
                return false;

            return
                (
                    this.NytdDes == input.NytdDes ||
                    this.NytdDes != null &&
                    input.NytdDes != null &&
                    this.NytdDes.SequenceEqual(input.NytdDes)
                ) &&
                (
                    this.NytdOrg == input.NytdOrg ||
                    this.NytdOrg != null &&
                    input.NytdOrg != null &&
                    this.NytdOrg.SequenceEqual(input.NytdOrg)
                ) &&
                (
                    this.NytdPer == input.NytdPer ||
                    this.NytdPer != null &&
                    input.NytdPer != null &&
                    this.NytdPer.SequenceEqual(input.NytdPer)
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
                if (this.NytdDes != null)
                    hashCode = hashCode * 59 + this.NytdDes.GetHashCode();
                if (this.NytdOrg != null)
                    hashCode = hashCode * 59 + this.NytdOrg.GetHashCode();
                if (this.NytdPer != null)
                    hashCode = hashCode * 59 + this.NytdPer.GetHashCode();
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