using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "multimedia")]
    public class CriticMultimediaWrapper : IEquatable<CriticMultimediaWrapper>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CriticMultimediaWrapper" /> class.
        /// </summary>
        /// <param name="resource">resource.</param>
        public CriticMultimediaWrapper(Multimedia resource = default)
        {
            this.Resource = resource;
        }

        /// <summary>
        /// Gets or Sets Resource
        /// </summary>
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        public Multimedia Resource { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CriticMultimediaWrapper {\n");
            sb.Append("  Resource: ").Append(Resource).Append('\n');
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
            return this.Equals(input as CriticMultimediaWrapper);
        }

        /// <summary>
        /// Returns true if CriticMultimediaWrapper instances are equal
        /// </summary>
        /// <param name="input">Instance of CriticMultimediaWrapper to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CriticMultimediaWrapper input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Resource == input.Resource ||
                    (this.Resource != null &&
                    this.Resource.Equals(input.Resource))
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
                if (this.Resource != null)
                    hashCode = hashCode * 59 + this.Resource.GetHashCode();
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
