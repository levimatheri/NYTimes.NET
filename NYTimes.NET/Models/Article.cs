using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "docs")]
    public class Article : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Article" /> class.
        /// </summary>
        /// <param name="webUrl">webUrl.</param>
        /// <param name="snippet">snippet.</param>
        /// <param name="printPage">printPage.</param>
        /// <param name="source">source.</param>
        /// <param name="multimedia">multimedia.</param>
        /// <param name="headline">headline.</param>
        /// <param name="keywords">keywords.</param>
        /// <param name="pubDate">pubDate.</param>
        /// <param name="documentType">documentType.</param>
        /// <param name="newsDesk">newsDesk.</param>
        /// <param name="byline">byline.</param>
        /// <param name="typeOfMaterial">typeOfMaterial.</param>
        /// <param name="id">id.</param>
        /// <param name="wordCount">wordCount.</param>
        /// <param name="score">score.</param>
        /// <param name="uri">uri.</param>
        public Article(string webUrl = default, string snippet = default, int printPage = default, 
            string source = default, List<Multimedia> multimedia = default, Headline headline = default,
            List<Keyword> keywords = default, string pubDate = default, string documentType = default, 
            string newsDesk = default, Byline byline = default, string typeOfMaterial = default, string id = default, 
            int wordCount = default, int score = default, string uri = default)
        {
            this.WebUrl = webUrl;
            this.Snippet = snippet;
            this.PrintPage = printPage;
            this.Source = source;
            this.Multimedia = multimedia;
            this.Headline = headline;
            this.Keywords = keywords;
            this.PubDate = pubDate;
            this.DocumentType = documentType;
            this.NewsDesk = newsDesk;
            this.Byline = byline;
            this.TypeOfMaterial = typeOfMaterial;
            this.Id = id;
            this.WordCount = wordCount;
            this.Score = score;
            this.Uri = uri;
        }

        /// <summary>
        /// Gets or Sets WebUrl
        /// </summary>
        [DataMember(Name = "web_url", EmitDefaultValue = false)]
        public string WebUrl { get; }

        /// <summary>
        /// Gets or Sets Snippet
        /// </summary>
        [DataMember(Name = "snippet", EmitDefaultValue = false)]
        public string Snippet { get; }

        /// <summary>
        /// Gets or Sets PrintPage
        /// </summary>
        [DataMember(Name = "print_page", EmitDefaultValue = false)]
        public int PrintPage { get; }

        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public string Source { get; }

        /// <summary>
        /// Gets or Sets Multimedia
        /// </summary>
        [DataMember(Name = "multimedia", EmitDefaultValue = false)]
        public List<Multimedia> Multimedia { get; }

        /// <summary>
        /// Gets or Sets Headline
        /// </summary>
        [DataMember(Name = "headline", EmitDefaultValue = false)]
        public Headline Headline { get; }

        /// <summary>
        /// Gets or Sets Keywords
        /// </summary>
        [DataMember(Name = "keywords", EmitDefaultValue = false)]
        public List<Keyword> Keywords { get; }

        /// <summary>
        /// Gets or Sets PubDate
        /// </summary>
        [DataMember(Name = "pub_date", EmitDefaultValue = false)]
        public string PubDate { get; }

        /// <summary>
        /// Gets or Sets DocumentType
        /// </summary>
        [DataMember(Name = "document_type", EmitDefaultValue = false)]
        public string DocumentType { get; }

        /// <summary>
        /// Gets or Sets NewsDesk
        /// </summary>
        [DataMember(Name = "news_desk", EmitDefaultValue = false)]
        public string NewsDesk { get; }

        /// <summary>
        /// Gets or Sets Byline
        /// </summary>
        [DataMember(Name = "byline", EmitDefaultValue = false)]
        public Byline Byline { get; }

        /// <summary>
        /// Gets or Sets TypeOfMaterial
        /// </summary>
        [DataMember(Name = "type_of_material", EmitDefaultValue = false)]
        public string TypeOfMaterial { get; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "_id", EmitDefaultValue = false)]
        public string Id { get; }

        /// <summary>
        /// Gets or Sets WordCount
        /// </summary>
        [DataMember(Name = "word_count", EmitDefaultValue = false)]
        public int WordCount { get; }

        /// <summary>
        /// Gets or Sets Score
        /// </summary>
        [DataMember(Name = "score", EmitDefaultValue = false)]
        public int Score { get; }

        /// <summary>
        /// Gets or Sets Uri
        /// </summary>
        [DataMember(Name = "uri", EmitDefaultValue = false)]
        public string Uri { get; }
    }
}
