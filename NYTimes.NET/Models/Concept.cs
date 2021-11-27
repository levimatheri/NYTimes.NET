using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class Concept : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Concept" /> class.
        /// </summary>
        /// <param name="conceptId">conceptId.</param>
        /// <param name="conceptName">conceptName.</param>
        /// <param name="isTimesTag">isTimesTag.</param>
        /// <param name="conceptStatus">conceptStatus.</param>
        /// <param name="vernacular">vernacular.</param>
        /// <param name="conceptType">conceptType.</param>
        /// <param name="conceptCreated">conceptCreated.</param>
        /// <param name="conceptUpdated">conceptUpdated.</param>
        /// <param name="taxonomy">taxonomy.</param>
        /// <param name="links">links.</param>
        /// <param name="searchApiQuery">searchApiQuery.</param>
        /// <param name="articleListWrapper">articleListWrapper.</param>
        /// <param name="scopeNotes">scopeNotes.</param>
        /// <param name="combinations">combinations.</param>
        /// <param name="ancestors">ancestors.</param>
        /// <param name="descendants">descendants.</param>
        public Concept(int conceptId = default, string conceptName = default, int isTimesTag = default, string conceptStatus = default,
            string vernacular = default, string conceptType = default, string conceptCreated = default, string conceptUpdated = default,
            List<ConceptTaxonomy> taxonomy = default, List<ConceptLink> links = default, string searchApiQuery = default, 
            ConceptArticleListWrapper articleListWrapper = default, List<ConceptScopeNote> scopeNotes = default, List<ConceptCombination> combinations = default,
            List<ConceptRelation> ancestors = default, List<ConceptRelation> descendants = default)
        {
            this.ConceptId = conceptId;
            this.ConceptName = conceptName;
            this.IsTimesTag = isTimesTag;
            this.ConceptStatus = conceptStatus;
            this.Vernacular = vernacular;
            this.ConceptType = conceptType;
            this.ConceptCreated = conceptCreated;
            this.ConceptUpdated = conceptUpdated;
            this.Taxonomy = taxonomy;
            this.Links = links;
            this.SearchApiQuery = searchApiQuery;
            this.ArticleList = articleListWrapper;
            this.ScopeNotes = scopeNotes;
            this.Combinations = combinations;
            this.Ancestors = ancestors;
            this.Descendants = descendants;
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
        /// Gets or Sets Taxonomy
        /// </summary>
        [DataMember(Name = "taxonomy", EmitDefaultValue = false)]
        public List<ConceptTaxonomy> Taxonomy { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        public List<ConceptLink> Links { get; set; }

        /// <summary>
        /// Gets or Sets SearchApiQuery
        /// </summary>
        [DataMember(Name = "search_api_query", EmitDefaultValue = false)]
        public string SearchApiQuery { get; set; }

        /// <summary>
        /// Gets or Sets ArticleList
        /// </summary>
        [DataMember(Name = "article_list", EmitDefaultValue = false)]
        public ConceptArticleListWrapper ArticleList { get; set; }

        /// <summary>
        /// Gets or Sets ScopeNotes
        /// </summary>
        [DataMember(Name = "scope_notes", EmitDefaultValue = false)]
        public List<ConceptScopeNote> ScopeNotes { get; set; }

        /// <summary>
        /// Gets or Sets Combinations
        /// </summary>
        [DataMember(Name = "combinations", EmitDefaultValue = false)]
        public List<ConceptCombination> Combinations { get; set; }

        /// <summary>
        /// Gets or Sets Ancestors
        /// </summary>
        [DataMember(Name = "ancestors", EmitDefaultValue = false)]
        public List<ConceptRelation> Ancestors { get; set; }

        /// <summary>
        /// Gets or Sets Descendants
        /// </summary>
        [DataMember(Name = "descendants", EmitDefaultValue = false)]
        public List<ConceptRelation> Descendants { get; set; }
    }
}
