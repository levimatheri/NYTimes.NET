using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class Concept : IEquatable<Concept>, IValidatableObject
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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Concept {\n");
            sb.Append("  ConceptId: ").Append(ConceptId).Append("\n");
            sb.Append("  ConceptName: ").Append(ConceptName).Append("\n");
            sb.Append("  IsTimesTag: ").Append(IsTimesTag).Append("\n");
            sb.Append("  ConceptStatus: ").Append(ConceptStatus).Append("\n");
            sb.Append("  Vernacular: ").Append(Vernacular).Append("\n");
            sb.Append("  ConceptType: ").Append(ConceptType).Append("\n");
            sb.Append("  ConceptCreated: ").Append(ConceptCreated).Append("\n");
            sb.Append("  ConceptUpdated: ").Append(ConceptUpdated).Append("\n");
            sb.Append("  Taxonomy: ").Append(Taxonomy).Append("\n");
            sb.Append("  Links: ").Append(Links).Append("\n");
            sb.Append("  SearchApiQuery: ").Append(SearchApiQuery).Append("\n");
            sb.Append("  ArticleList: ").Append(ArticleList).Append("\n");
            sb.Append("  ScopeNotes: ").Append(ScopeNotes).Append("\n");
            sb.Append("  Combinations: ").Append(Combinations).Append("\n");
            sb.Append("  Ancestors: ").Append(Ancestors).Append("\n");
            sb.Append("  Descendants: ").Append(Descendants).Append("\n");
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
            return this.Equals(input as Concept);
        }

        /// <summary>
        /// Returns true if Concept instances are equal
        /// </summary>
        /// <param name="input">Instance of Concept to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Concept input)
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
                ) &&
                (
                    this.Taxonomy == input.Taxonomy ||
                    this.Taxonomy != null &&
                    input.Taxonomy != null &&
                    this.Taxonomy.SequenceEqual(input.Taxonomy)
                ) &&
                (
                    this.Links == input.Links ||
                    this.Links != null &&
                    input.Links != null &&
                    this.Links.SequenceEqual(input.Links)
                ) &&
                (
                    this.SearchApiQuery == input.SearchApiQuery ||
                    (this.SearchApiQuery != null &&
                    this.SearchApiQuery.Equals(input.SearchApiQuery))
                ) &&
                (
                    this.ArticleList == input.ArticleList ||
                    (this.ArticleList != null &&
                    this.ArticleList.Equals(input.ArticleList))
                ) &&
                (
                    this.ScopeNotes == input.ScopeNotes ||
                    this.ScopeNotes != null &&
                    input.ScopeNotes != null &&
                    this.ScopeNotes.SequenceEqual(input.ScopeNotes)
                ) &&
                (
                    this.Combinations == input.Combinations ||
                    this.Combinations != null &&
                    input.Combinations != null &&
                    this.Combinations.SequenceEqual(input.Combinations)
                ) &&
                (
                    this.Ancestors == input.Ancestors ||
                    this.Ancestors != null &&
                    input.Ancestors != null &&
                    this.Ancestors.SequenceEqual(input.Ancestors)
                ) &&
                (
                    this.Descendants == input.Descendants ||
                    this.Descendants != null &&
                    input.Descendants != null &&
                    this.Descendants.SequenceEqual(input.Descendants)
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
                if (this.Taxonomy != null)
                    hashCode = hashCode * 59 + this.Taxonomy.GetHashCode();
                if (this.Links != null)
                    hashCode = hashCode * 59 + this.Links.GetHashCode();
                if (this.SearchApiQuery != null)
                    hashCode = hashCode * 59 + this.SearchApiQuery.GetHashCode();
                if (this.ArticleList != null)
                    hashCode = hashCode * 59 + this.ArticleList.GetHashCode();
                if (this.ScopeNotes != null)
                    hashCode = hashCode * 59 + this.ScopeNotes.GetHashCode();
                if (this.Combinations != null)
                    hashCode = hashCode * 59 + this.Combinations.GetHashCode();
                if (this.Ancestors != null)
                    hashCode = hashCode * 59 + this.Ancestors.GetHashCode();
                if (this.Descendants != null)
                    hashCode = hashCode * 59 + this.Descendants.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
