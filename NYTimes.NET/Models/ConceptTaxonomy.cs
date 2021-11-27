using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "taxonomy")]
    public class ConceptTaxonomy : ModelBase
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
    }
}