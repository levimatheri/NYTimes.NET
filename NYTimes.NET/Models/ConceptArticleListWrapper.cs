using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "article_list")]
    public class ConceptArticleListWrapper : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptArticleListWrapper" /> class.
        /// </summary>
        /// <param name="articles">results.</param>
        /// <param name="total">total.</param>
        public ConceptArticleListWrapper(List<ConceptArticle> articles = default, int total = default(int))
        {
            this.Articles = articles;
            this.Total = total;
        }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name = "results", EmitDefaultValue = false)]
        public List<ConceptArticle> Articles { get; set; }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; set; }
    }
}