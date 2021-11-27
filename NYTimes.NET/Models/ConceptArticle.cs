using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class ConceptArticle : Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptArticle" /> class.
        /// </summary>
        /// <param name="body">body.</param>
        /// <param name="byline">byline.</param>
        /// <param name="concepts">concepts.</param>
        /// <param name="date">date.</param>
        /// <param name="documentType">documentType.</param>
        /// <param name="title">title.</param>
        /// <param name="typeOfMaterial">typeOfMaterial.</param>
        /// <param name="url">url.</param>
        public ConceptArticle(string body = default, string byline = default, ConceptArticleListConcepts concepts = default, string date = default,
            string documentType = default, string title = default, string typeOfMaterial = default, string url = default)
            : base(byline: new Byline(original: byline), documentType: documentType, typeOfMaterial: typeOfMaterial)
        {
            this.Body = body;
            this.Concepts = concepts;
            this.Date = date;
            this.Title = title;
            this.Url = url;
        }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        [DataMember(Name = "body", EmitDefaultValue = false)]
        public string Body { get; set; }

        /// <summary>
        /// Gets or Sets Concepts
        /// </summary>
        [DataMember(Name = "concepts", EmitDefaultValue = false)]
        public ConceptArticleListConcepts Concepts { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }
    }
}