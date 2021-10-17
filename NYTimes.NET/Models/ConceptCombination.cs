using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "combinations")]
    public class ConceptCombination : IEquatable<ConceptCombination>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptCombination" /> class.
        /// </summary>
        /// <param name="combinationSourceConceptId">combinationSourceConceptId.</param>
        /// <param name="combinationSourceConceptName">combinationSourceConceptName.</param>
        /// <param name="combinationSourceConceptType">combinationSourceConceptType.</param>
        /// <param name="combinationTargetConceptId">combinationTargetConceptId.</param>
        /// <param name="combinationTargetConceptName">combinationTargetConceptName.</param>
        /// <param name="combinationTargetConceptType">combinationTargetConceptType.</param>
        /// <param name="combinationNote">combinationNote.</param>
        public ConceptCombination(int combinationSourceConceptId = default(int), string combinationSourceConceptName = default(string), string combinationSourceConceptType = default(string), int combinationTargetConceptId = default(int), string combinationTargetConceptName = default(string), string combinationTargetConceptType = default(string), string combinationNote = default(string))
        {
            this.CombinationSourceConceptId = combinationSourceConceptId;
            this.CombinationSourceConceptName = combinationSourceConceptName;
            this.CombinationSourceConceptType = combinationSourceConceptType;
            this.CombinationTargetConceptId = combinationTargetConceptId;
            this.CombinationTargetConceptName = combinationTargetConceptName;
            this.CombinationTargetConceptType = combinationTargetConceptType;
            this.CombinationNote = combinationNote;
        }

        /// <summary>
        /// Gets or Sets CombinationSourceConceptId
        /// </summary>
        [DataMember(Name = "combination_source_concept_id", EmitDefaultValue = false)]
        public int CombinationSourceConceptId { get; set; }

        /// <summary>
        /// Gets or Sets CombinationSourceConceptName
        /// </summary>
        [DataMember(Name = "combination_source_concept_name", EmitDefaultValue = false)]
        public string CombinationSourceConceptName { get; set; }

        /// <summary>
        /// Gets or Sets CombinationSourceConceptType
        /// </summary>
        [DataMember(Name = "combination_source_concept_type", EmitDefaultValue = false)]
        public string CombinationSourceConceptType { get; set; }

        /// <summary>
        /// Gets or Sets CombinationTargetConceptId
        /// </summary>
        [DataMember(Name = "combination_target_concept_id", EmitDefaultValue = false)]
        public int CombinationTargetConceptId { get; set; }

        /// <summary>
        /// Gets or Sets CombinationTargetConceptName
        /// </summary>
        [DataMember(Name = "combination_target_concept_name", EmitDefaultValue = false)]
        public string CombinationTargetConceptName { get; set; }

        /// <summary>
        /// Gets or Sets CombinationTargetConceptType
        /// </summary>
        [DataMember(Name = "combination_target_concept_type", EmitDefaultValue = false)]
        public string CombinationTargetConceptType { get; set; }

        /// <summary>
        /// Gets or Sets CombinationNote
        /// </summary>
        [DataMember(Name = "combination_note", EmitDefaultValue = false)]
        public string CombinationNote { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptCombination {\n");
            sb.Append("  CombinationSourceConceptId: ").Append(CombinationSourceConceptId).Append("\n");
            sb.Append("  CombinationSourceConceptName: ").Append(CombinationSourceConceptName).Append("\n");
            sb.Append("  CombinationSourceConceptType: ").Append(CombinationSourceConceptType).Append("\n");
            sb.Append("  CombinationTargetConceptId: ").Append(CombinationTargetConceptId).Append("\n");
            sb.Append("  CombinationTargetConceptName: ").Append(CombinationTargetConceptName).Append("\n");
            sb.Append("  CombinationTargetConceptType: ").Append(CombinationTargetConceptType).Append("\n");
            sb.Append("  CombinationNote: ").Append(CombinationNote).Append("\n");
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
            return this.Equals(input as ConceptCombination);
        }

        /// <summary>
        /// Returns true if ConceptCombination instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptCombination to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptCombination input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CombinationSourceConceptId == input.CombinationSourceConceptId ||
                    this.CombinationSourceConceptId.Equals(input.CombinationSourceConceptId)
                ) &&
                (
                    this.CombinationSourceConceptName == input.CombinationSourceConceptName ||
                    (this.CombinationSourceConceptName != null &&
                    this.CombinationSourceConceptName.Equals(input.CombinationSourceConceptName))
                ) &&
                (
                    this.CombinationSourceConceptType == input.CombinationSourceConceptType ||
                    (this.CombinationSourceConceptType != null &&
                    this.CombinationSourceConceptType.Equals(input.CombinationSourceConceptType))
                ) &&
                (
                    this.CombinationTargetConceptId == input.CombinationTargetConceptId ||
                    this.CombinationTargetConceptId.Equals(input.CombinationTargetConceptId)
                ) &&
                (
                    this.CombinationTargetConceptName == input.CombinationTargetConceptName ||
                    (this.CombinationTargetConceptName != null &&
                    this.CombinationTargetConceptName.Equals(input.CombinationTargetConceptName))
                ) &&
                (
                    this.CombinationTargetConceptType == input.CombinationTargetConceptType ||
                    (this.CombinationTargetConceptType != null &&
                    this.CombinationTargetConceptType.Equals(input.CombinationTargetConceptType))
                ) &&
                (
                    this.CombinationNote == input.CombinationNote ||
                    (this.CombinationNote != null &&
                    this.CombinationNote.Equals(input.CombinationNote))
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
                int hashCode = 41;
                hashCode = hashCode * 59 + this.CombinationSourceConceptId.GetHashCode();
                if (this.CombinationSourceConceptName != null)
                    hashCode = hashCode * 59 + this.CombinationSourceConceptName.GetHashCode();
                if (this.CombinationSourceConceptType != null)
                    hashCode = hashCode * 59 + this.CombinationSourceConceptType.GetHashCode();
                hashCode = hashCode * 59 + this.CombinationTargetConceptId.GetHashCode();
                if (this.CombinationTargetConceptName != null)
                    hashCode = hashCode * 59 + this.CombinationTargetConceptName.GetHashCode();
                if (this.CombinationTargetConceptType != null)
                    hashCode = hashCode * 59 + this.CombinationTargetConceptType.GetHashCode();
                if (this.CombinationNote != null)
                    hashCode = hashCode * 59 + this.CombinationNote.GetHashCode();
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