using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "concepts")]
    public class ConceptArticleListConcepts : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptArticleListConcepts" /> class.
        /// </summary>
        /// <param name="nytdDes">nytdDes.</param>
        /// <param name="nytdOrg">nytdOrg.</param>
        /// <param name="nytdPer">nytdPer.</param>
        public ConceptArticleListConcepts(List<string> nytdDes = default, List<string> nytdOrg = default, List<string> nytdPer = default)
        {
            this.NytdDes = nytdDes;
            this.NytdOrg = nytdOrg;
            this.NytdPer = nytdPer;
        }

        /// <summary>
        /// Gets or Sets NytdDes
        /// </summary>
        [DataMember(Name = "nytd_des", EmitDefaultValue = false)]
        public List<string> NytdDes { get; set; }

        /// <summary>
        /// Gets or Sets NytdOrg
        /// </summary>
        [DataMember(Name = "nytd_org", EmitDefaultValue = false)]
        public List<string> NytdOrg { get; set; }

        /// <summary>
        /// Gets or Sets NytdPer
        /// </summary>
        [DataMember(Name = "nytd_per", EmitDefaultValue = false)]
        public List<string> NytdPer { get; set; }
    }
}