using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "links")]
    public class ConceptLink : ModelBase
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
    }
}