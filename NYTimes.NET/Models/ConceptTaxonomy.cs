using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "taxonomy")]
    public class ConceptTaxonomy : IEquatable<ConceptTaxonomy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptTaxonomy" /> class.
        /// </summary>
        /// <param name="sourceConceptId">sourceConceptId.</param>
        /// <param name="targetConceptId">targetConceptId.</param>
        /// <param name="sourceConceptName">sourceConceptName.</param>
        /// <param name="targetConceptName">targetConceptName.</param>
        /// <param name="sourceConceptType">sourceConceptType.</param>
        /// <param name="targetConceptType">targetConceptType.</param>
        /// <param name="sourceConceptVernacular">sourceConceptVernacular.</param>
        /// <param name="targetConceptVernacular">targetConceptVernacular.</param>
        /// <param name="taxonomicRelation">taxonomicRelation.</param>
        /// <param name="taxonomicVerificationStatus">taxonomicVerificationStatus.</param>
        public ConceptTaxonomy(int sourceConceptId = default, int targetConceptId = default, string sourceConceptName = default, string targetConceptName = default,
            string sourceConceptType = default, string targetConceptType = default, string sourceConceptVernacular = default, string targetConceptVernacular = default,
            string taxonomicRelation = default, string taxonomicVerificationStatus = default)
        {
            this.SourceConceptId = sourceConceptId;
            this.TargetConceptId = targetConceptId;
            this.SourceConceptName = sourceConceptName;
            this.TargetConceptName = targetConceptName;
            this.SourceConceptType = sourceConceptType;
            this.TargetConceptType = targetConceptType;
            this.SourceConceptVernacular = sourceConceptVernacular;
            this.TargetConceptVernacular = targetConceptVernacular;
            this.TaxonomicRelation = taxonomicRelation;
            this.TaxonomicVerificationStatus = taxonomicVerificationStatus;
        }

        /// <summary>
        /// Gets or Sets SourceConceptId
        /// </summary>
        [DataMember(Name = "source_concept_id", EmitDefaultValue = false)]
        public int SourceConceptId { get; set; }

        /// <summary>
        /// Gets or Sets TargetConceptId
        /// </summary>
        [DataMember(Name = "target_concept_id", EmitDefaultValue = false)]
        public int TargetConceptId { get; set; }

        /// <summary>
        /// Gets or Sets SourceConceptName
        /// </summary>
        [DataMember(Name = "source_concept_name", EmitDefaultValue = false)]
        public string SourceConceptName { get; set; }

        /// <summary>
        /// Gets or Sets TargetConceptName
        /// </summary>
        [DataMember(Name = "target_concept_name", EmitDefaultValue = false)]
        public string TargetConceptName { get; set; }

        /// <summary>
        /// Gets or Sets SourceConceptType
        /// </summary>
        [DataMember(Name = "source_concept_type", EmitDefaultValue = false)]
        public string SourceConceptType { get; set; }

        /// <summary>
        /// Gets or Sets TargetConceptType
        /// </summary>
        [DataMember(Name = "target_concept_type", EmitDefaultValue = false)]
        public string TargetConceptType { get; set; }

        /// <summary>
        /// Gets or Sets SourceConceptVernacular
        /// </summary>
        [DataMember(Name = "source_concept_vernacular", EmitDefaultValue = false)]
        public string SourceConceptVernacular { get; set; }

        /// <summary>
        /// Gets or Sets TargetConceptVernacular
        /// </summary>
        [DataMember(Name = "target_concept_vernacular", EmitDefaultValue = false)]
        public string TargetConceptVernacular { get; set; }

        /// <summary>
        /// Gets or Sets TaxonomicRelation
        /// </summary>
        [DataMember(Name = "taxonomic_relation", EmitDefaultValue = false)]
        public string TaxonomicRelation { get; set; }

        /// <summary>
        /// Gets or Sets TaxonomicVerificationStatus
        /// </summary>
        [DataMember(Name = "taxonomic_verification_status", EmitDefaultValue = false)]
        public string TaxonomicVerificationStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptTaxonomy {\n");
            sb.Append("  SourceConceptId: ").Append(SourceConceptId).Append('\n');
            sb.Append("  TargetConceptId: ").Append(TargetConceptId).Append('\n');
            sb.Append("  SourceConceptName: ").Append(SourceConceptName).Append('\n');
            sb.Append("  TargetConceptName: ").Append(TargetConceptName).Append('\n');
            sb.Append("  SourceConceptType: ").Append(SourceConceptType).Append('\n');
            sb.Append("  TargetConceptType: ").Append(TargetConceptType).Append('\n');
            sb.Append("  SourceConceptVernacular: ").Append(SourceConceptVernacular).Append('\n');
            sb.Append("  TargetConceptVernacular: ").Append(TargetConceptVernacular).Append('\n');
            sb.Append("  TaxonomicRelation: ").Append(TaxonomicRelation).Append('\n');
            sb.Append("  TaxonomicVerificationStatus: ").Append(TaxonomicVerificationStatus).Append('\n');
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
            return this.Equals(input as ConceptTaxonomy);
        }

        /// <summary>
        /// Returns true if ConceptTaxonomy instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptTaxonomy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptTaxonomy input)
        {
            if (input == null)
                return false;

            return
                (
                    this.SourceConceptId == input.SourceConceptId ||
                    this.SourceConceptId.Equals(input.SourceConceptId)
                ) &&
                (
                    this.TargetConceptId == input.TargetConceptId ||
                    this.TargetConceptId.Equals(input.TargetConceptId)
                ) &&
                (
                    this.SourceConceptName == input.SourceConceptName ||
                    (this.SourceConceptName != null &&
                    this.SourceConceptName.Equals(input.SourceConceptName))
                ) &&
                (
                    this.TargetConceptName == input.TargetConceptName ||
                    (this.TargetConceptName != null &&
                    this.TargetConceptName.Equals(input.TargetConceptName))
                ) &&
                (
                    this.SourceConceptType == input.SourceConceptType ||
                    (this.SourceConceptType != null &&
                    this.SourceConceptType.Equals(input.SourceConceptType))
                ) &&
                (
                    this.TargetConceptType == input.TargetConceptType ||
                    (this.TargetConceptType != null &&
                    this.TargetConceptType.Equals(input.TargetConceptType))
                ) &&
                (
                    this.SourceConceptVernacular == input.SourceConceptVernacular ||
                    (this.SourceConceptVernacular != null &&
                    this.SourceConceptVernacular.Equals(input.SourceConceptVernacular))
                ) &&
                (
                    this.TargetConceptVernacular == input.TargetConceptVernacular ||
                    (this.TargetConceptVernacular != null &&
                    this.TargetConceptVernacular.Equals(input.TargetConceptVernacular))
                ) &&
                (
                    this.TaxonomicRelation == input.TaxonomicRelation ||
                    (this.TaxonomicRelation != null &&
                    this.TaxonomicRelation.Equals(input.TaxonomicRelation))
                ) &&
                (
                    this.TaxonomicVerificationStatus == input.TaxonomicVerificationStatus ||
                    (this.TaxonomicVerificationStatus != null &&
                    this.TaxonomicVerificationStatus.Equals(input.TaxonomicVerificationStatus))
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
                hashCode = hashCode * 59 + this.SourceConceptId.GetHashCode();
                hashCode = hashCode * 59 + this.TargetConceptId.GetHashCode();
                if (this.SourceConceptName != null)
                    hashCode = hashCode * 59 + this.SourceConceptName.GetHashCode();
                if (this.TargetConceptName != null)
                    hashCode = hashCode * 59 + this.TargetConceptName.GetHashCode();
                if (this.SourceConceptType != null)
                    hashCode = hashCode * 59 + this.SourceConceptType.GetHashCode();
                if (this.TargetConceptType != null)
                    hashCode = hashCode * 59 + this.TargetConceptType.GetHashCode();
                if (this.SourceConceptVernacular != null)
                    hashCode = hashCode * 59 + this.SourceConceptVernacular.GetHashCode();
                if (this.TargetConceptVernacular != null)
                    hashCode = hashCode * 59 + this.TargetConceptVernacular.GetHashCode();
                if (this.TaxonomicRelation != null)
                    hashCode = hashCode * 59 + this.TaxonomicRelation.GetHashCode();
                if (this.TaxonomicVerificationStatus != null)
                    hashCode = hashCode * 59 + this.TaxonomicVerificationStatus.GetHashCode();
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