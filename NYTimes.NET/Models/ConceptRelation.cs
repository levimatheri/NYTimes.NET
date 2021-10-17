using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "docs")]
    public class ConceptRelation : IEquatable<ConceptRelation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptRelation" /> class.
        /// </summary>
        /// <param name="conceptId">conceptId.</param>
        /// <param name="conceptName">conceptName.</param>
        /// <param name="isTimesTag">isTimesTag.</param>
        /// <param name="conceptStatus">conceptStatus.</param>
        /// <param name="vernacular">vernacular.</param>
        /// <param name="conceptType">conceptType.</param>
        /// <param name="conceptCreated">conceptCreated.</param>
        /// <param name="conceptUpdated">conceptUpdated.</param>
        public ConceptRelation(int conceptId = default, string conceptName = default, int isTimesTag = default, string conceptStatus = default, string vernacular = default, string conceptType = default, string conceptCreated = default, string conceptUpdated = default)
        {
            this.ConceptId = conceptId;
            this.ConceptName = conceptName;
            this.IsTimesTag = isTimesTag;
            this.ConceptStatus = conceptStatus;
            this.Vernacular = vernacular;
            this.ConceptType = conceptType;
            this.ConceptCreated = conceptCreated;
            this.ConceptUpdated = conceptUpdated;
        }

        /// <summary>
        /// Gets or Sets ConceptId
        /// </summary>
        [DataMember(Name = "concept_id", EmitDefaultValue = false)]
        public int ConceptId { get; set; }

        /// <summary>
        /// Gets or Sets ConceptName
        /// </summary>
        [DataMember(Name = "concept_name", EmitDefaultValue = false)]
        public string ConceptName { get; set; }

        /// <summary>
        /// Gets or Sets IsTimesTag
        /// </summary>
        [DataMember(Name = "is_times_tag", EmitDefaultValue = false)]
        public int IsTimesTag { get; set; }

        /// <summary>
        /// Gets or Sets ConceptStatus
        /// </summary>
        [DataMember(Name = "concept_status", EmitDefaultValue = false)]
        public string ConceptStatus { get; set; }

        /// <summary>
        /// Gets or Sets Vernacular
        /// </summary>
        [DataMember(Name = "vernacular", EmitDefaultValue = false)]
        public string Vernacular { get; set; }

        /// <summary>
        /// Gets or Sets ConceptType
        /// </summary>
        [DataMember(Name = "concept_type", EmitDefaultValue = false)]
        public string ConceptType { get; set; }

        /// <summary>
        /// Gets or Sets ConceptCreated
        /// </summary>
        [DataMember(Name = "concept_created", EmitDefaultValue = false)]
        public string ConceptCreated { get; set; }

        /// <summary>
        /// Gets or Sets ConceptUpdated
        /// </summary>
        [DataMember(Name = "concept_updated", EmitDefaultValue = false)]
        public string ConceptUpdated { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptRelation {\n");
            sb.Append("  ConceptId: ").Append(ConceptId).Append("\n");
            sb.Append("  ConceptName: ").Append(ConceptName).Append("\n");
            sb.Append("  IsTimesTag: ").Append(IsTimesTag).Append("\n");
            sb.Append("  ConceptStatus: ").Append(ConceptStatus).Append("\n");
            sb.Append("  Vernacular: ").Append(Vernacular).Append("\n");
            sb.Append("  ConceptType: ").Append(ConceptType).Append("\n");
            sb.Append("  ConceptCreated: ").Append(ConceptCreated).Append("\n");
            sb.Append("  ConceptUpdated: ").Append(ConceptUpdated).Append("\n");
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
            return this.Equals(input as ConceptRelation);
        }

        /// <summary>
        /// Returns true if ConceptRelation instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptRelation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptRelation input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ConceptId == input.ConceptId ||
                    this.ConceptId.Equals(input.ConceptId)
                ) &&
                (
                    this.ConceptName == input.ConceptName ||
                    (this.ConceptName != null &&
                    this.ConceptName.Equals(input.ConceptName))
                ) &&
                (
                    this.IsTimesTag == input.IsTimesTag ||
                    this.IsTimesTag.Equals(input.IsTimesTag)
                ) &&
                (
                    this.ConceptStatus == input.ConceptStatus ||
                    (this.ConceptStatus != null &&
                    this.ConceptStatus.Equals(input.ConceptStatus))
                ) &&
                (
                    this.Vernacular == input.Vernacular ||
                    (this.Vernacular != null &&
                    this.Vernacular.Equals(input.Vernacular))
                ) &&
                (
                    this.ConceptType == input.ConceptType ||
                    (this.ConceptType != null &&
                    this.ConceptType.Equals(input.ConceptType))
                ) &&
                (
                    this.ConceptCreated == input.ConceptCreated ||
                    (this.ConceptCreated != null &&
                    this.ConceptCreated.Equals(input.ConceptCreated))
                ) &&
                (
                    this.ConceptUpdated == input.ConceptUpdated ||
                    (this.ConceptUpdated != null &&
                    this.ConceptUpdated.Equals(input.ConceptUpdated))
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
                hashCode = hashCode * 59 + this.ConceptId.GetHashCode();
                if (this.ConceptName != null)
                    hashCode = hashCode * 59 + this.ConceptName.GetHashCode();
                hashCode = hashCode * 59 + this.IsTimesTag.GetHashCode();
                if (this.ConceptStatus != null)
                    hashCode = hashCode * 59 + this.ConceptStatus.GetHashCode();
                if (this.Vernacular != null)
                    hashCode = hashCode * 59 + this.Vernacular.GetHashCode();
                if (this.ConceptType != null)
                    hashCode = hashCode * 59 + this.ConceptType.GetHashCode();
                if (this.ConceptCreated != null)
                    hashCode = hashCode * 59 + this.ConceptCreated.GetHashCode();
                if (this.ConceptUpdated != null)
                    hashCode = hashCode * 59 + this.ConceptUpdated.GetHashCode();
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