using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "links")]
    public class ConceptLink : IEquatable<ConceptLink>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptLink" /> class.
        /// </summary>
        /// <param name="conceptId">conceptId.</param>
        /// <param name="conceptName">conceptName.</param>
        /// <param name="conceptStatus">conceptStatus.</param>
        /// <param name="isTimesTag">isTimesTag.</param>
        /// <param name="conceptType">conceptType.</param>
        /// <param name="linkId">linkId.</param>
        /// <param name="relation">relation.</param>
        /// <param name="link">link.</param>
        /// <param name="linkType">linkType.</param>
        /// <param name="mappingType">mappingType.</param>
        public ConceptLink(int conceptId = default, string conceptName = default, string conceptStatus = default, int isTimesTag = default, string conceptType = default, int linkId = default, string relation = default, string link = default, string linkType = default, string mappingType = default)
        {
            this.ConceptId = conceptId;
            this.ConceptName = conceptName;
            this.ConceptStatus = conceptStatus;
            this.IsTimesTag = isTimesTag;
            this.ConceptType = conceptType;
            this.LinkId = linkId;
            this.Relation = relation;
            this.Link = link;
            this.LinkType = linkType;
            this.MappingType = mappingType;
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
        /// Gets or Sets ConceptStatus
        /// </summary>
        [DataMember(Name = "concept_status", EmitDefaultValue = false)]
        public string ConceptStatus { get; set; }

        /// <summary>
        /// Gets or Sets IsTimesTag
        /// </summary>
        [DataMember(Name = "is_times_tag", EmitDefaultValue = false)]
        public int IsTimesTag { get; set; }

        /// <summary>
        /// Gets or Sets ConceptType
        /// </summary>
        [DataMember(Name = "concept_type", EmitDefaultValue = false)]
        public string ConceptType { get; set; }

        /// <summary>
        /// Gets or Sets LinkId
        /// </summary>
        [DataMember(Name = "link_id", EmitDefaultValue = false)]
        public int LinkId { get; set; }

        /// <summary>
        /// Gets or Sets Relation
        /// </summary>
        [DataMember(Name = "relation", EmitDefaultValue = false)]
        public string Relation { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }

        /// <summary>
        /// Gets or Sets LinkType
        /// </summary>
        [DataMember(Name = "link_type", EmitDefaultValue = false)]
        public string LinkType { get; set; }

        /// <summary>
        /// Gets or Sets MappingType
        /// </summary>
        [DataMember(Name = "mapping_type", EmitDefaultValue = false)]
        public string MappingType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptLink {\n");
            sb.Append("  ConceptId: ").Append(ConceptId).Append("\n");
            sb.Append("  ConceptName: ").Append(ConceptName).Append("\n");
            sb.Append("  ConceptStatus: ").Append(ConceptStatus).Append("\n");
            sb.Append("  IsTimesTag: ").Append(IsTimesTag).Append("\n");
            sb.Append("  ConceptType: ").Append(ConceptType).Append("\n");
            sb.Append("  LinkId: ").Append(LinkId).Append("\n");
            sb.Append("  Relation: ").Append(Relation).Append("\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  LinkType: ").Append(LinkType).Append("\n");
            sb.Append("  MappingType: ").Append(MappingType).Append("\n");
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
            return this.Equals(input as ConceptLink);
        }

        /// <summary>
        /// Returns true if ConceptLink instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptLink to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptLink input)
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
                    this.ConceptStatus == input.ConceptStatus ||
                    (this.ConceptStatus != null &&
                    this.ConceptStatus.Equals(input.ConceptStatus))
                ) &&
                (
                    this.IsTimesTag == input.IsTimesTag ||
                    this.IsTimesTag.Equals(input.IsTimesTag)
                ) &&
                (
                    this.ConceptType == input.ConceptType ||
                    (this.ConceptType != null &&
                    this.ConceptType.Equals(input.ConceptType))
                ) &&
                (
                    this.LinkId == input.LinkId ||
                    this.LinkId.Equals(input.LinkId)
                ) &&
                (
                    this.Relation == input.Relation ||
                    (this.Relation != null &&
                    this.Relation.Equals(input.Relation))
                ) &&
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
                ) &&
                (
                    this.LinkType == input.LinkType ||
                    (this.LinkType != null &&
                    this.LinkType.Equals(input.LinkType))
                ) &&
                (
                    this.MappingType == input.MappingType ||
                    (this.MappingType != null &&
                    this.MappingType.Equals(input.MappingType))
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
                hashCode = hashCode * 59 + this.ConceptId.GetHashCode();
                if (this.ConceptName != null)
                    hashCode = hashCode * 59 + this.ConceptName.GetHashCode();
                if (this.ConceptStatus != null)
                    hashCode = hashCode * 59 + this.ConceptStatus.GetHashCode();
                hashCode = hashCode * 59 + this.IsTimesTag.GetHashCode();
                if (this.ConceptType != null)
                    hashCode = hashCode * 59 + this.ConceptType.GetHashCode();
                hashCode = hashCode * 59 + this.LinkId.GetHashCode();
                if (this.Relation != null)
                    hashCode = hashCode * 59 + this.Relation.GetHashCode();
                if (this.Link != null)
                    hashCode = hashCode * 59 + this.Link.GetHashCode();
                if (this.LinkType != null)
                    hashCode = hashCode * 59 + this.LinkType.GetHashCode();
                if (this.MappingType != null)
                    hashCode = hashCode * 59 + this.MappingType.GetHashCode();
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