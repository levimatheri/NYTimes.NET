using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "docs")]
    public class ConceptRelation : ModelBase
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
    }
}