using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "combinations")]
    public class ConceptCombination : ModelBase
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
    }
}