using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "docs")]
    public class Article : IEquatable<Article>, IValidatableObject
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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Article {\n");
            sb.Append("  WebUrl: ").Append(WebUrl).Append('\n');
            sb.Append("  Snippet: ").Append(Snippet).Append('\n');
            sb.Append("  PrintPage: ").Append(PrintPage).Append('\n');
            sb.Append("  Source: ").Append(Source).Append('\n');
            sb.Append("  Multimedia: ").Append(Multimedia).Append('\n');
            sb.Append("  Headline: ").Append(Headline).Append('\n');
            sb.Append("  Keywords: ").Append(Keywords).Append('\n');
            sb.Append("  PubDate: ").Append(PubDate).Append('\n');
            sb.Append("  DocumentType: ").Append(DocumentType).Append('\n');
            sb.Append("  NewsDesk: ").Append(NewsDesk).Append('\n');
            sb.Append("  Byline: ").Append(Byline).Append('\n');
            sb.Append("  TypeOfMaterial: ").Append(TypeOfMaterial).Append('\n');
            sb.Append("  Id: ").Append(Id).Append('\n');
            sb.Append("  WordCount: ").Append(WordCount).Append('\n');
            sb.Append("  Score: ").Append(Score).Append('\n');
            sb.Append("  Uri: ").Append(Uri).Append('\n');
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
            return this.Equals(input as Article);
        }

        /// <summary>
        /// Returns true if Article instances are equal
        /// </summary>
        /// <param name="input">Instance of Article to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Article input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.WebUrl == input.WebUrl ||
                    (this.WebUrl != null &&
                    this.WebUrl.Equals(input.WebUrl))
                ) && 
                (
                    this.Snippet == input.Snippet ||
                    (this.Snippet != null &&
                    this.Snippet.Equals(input.Snippet))
                ) && 
                (
                    this.PrintPage == input.PrintPage ||
                    this.PrintPage.Equals(input.PrintPage)
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.Multimedia == input.Multimedia ||
                    this.Multimedia != null &&
                    input.Multimedia != null &&
                    this.Multimedia.SequenceEqual(input.Multimedia)
                ) && 
                (
                    this.Headline.Equals(input.Headline) ||
                    (this.Headline != null &&
                    this.Headline.Equals(input.Headline))
                ) && 
                (
                    this.Keywords == input.Keywords ||
                    this.Keywords != null &&
                    input.Keywords != null &&
                    this.Keywords.SequenceEqual(input.Keywords)
                ) && 
                (
                    this.PubDate == input.PubDate ||
                    (this.PubDate != null &&
                    this.PubDate.Equals(input.PubDate))
                ) && 
                (
                    this.DocumentType == input.DocumentType ||
                    (this.DocumentType != null &&
                    this.DocumentType.Equals(input.DocumentType))
                ) && 
                (
                    this.NewsDesk == input.NewsDesk ||
                    (this.NewsDesk != null &&
                    this.NewsDesk.Equals(input.NewsDesk))
                ) && 
                (
                    this.Byline.Equals(input.Byline) ||
                    (this.Byline != null &&
                    this.Byline.Equals(input.Byline))
                ) && 
                (
                    this.TypeOfMaterial == input.TypeOfMaterial ||
                    (this.TypeOfMaterial != null &&
                    this.TypeOfMaterial.Equals(input.TypeOfMaterial))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.WordCount == input.WordCount ||
                    this.WordCount.Equals(input.WordCount)
                ) && 
                (
                    this.Score == input.Score ||
                    this.Score.Equals(input.Score)
                ) && 
                (
                    this.Uri == input.Uri ||
                    (this.Uri != null &&
                    this.Uri.Equals(input.Uri))
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
                var hashCode = 41;
                if (this.WebUrl != null)
                    hashCode = hashCode * 59 + this.WebUrl.GetHashCode();
                if (this.Snippet != null)
                    hashCode = hashCode * 59 + this.Snippet.GetHashCode();
                hashCode = hashCode * 59 + this.PrintPage.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.Multimedia != null)
                    hashCode = hashCode * 59 + this.Multimedia.GetHashCode();
                if (this.Headline != null)
                    hashCode = hashCode * 59 + this.Headline.GetHashCode();
                if (this.Keywords != null)
                    hashCode = hashCode * 59 + this.Keywords.GetHashCode();
                if (this.PubDate != null)
                    hashCode = hashCode * 59 + this.PubDate.GetHashCode();
                if (this.DocumentType != null)
                    hashCode = hashCode * 59 + this.DocumentType.GetHashCode();
                if (this.NewsDesk != null)
                    hashCode = hashCode * 59 + this.NewsDesk.GetHashCode();
                if (this.Byline != null)
                    hashCode = hashCode * 59 + this.Byline.GetHashCode();
                if (this.TypeOfMaterial != null)
                    hashCode = hashCode * 59 + this.TypeOfMaterial.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                hashCode = hashCode * 59 + this.WordCount.GetHashCode();
                hashCode = hashCode * 59 + this.Score.GetHashCode();
                if (this.Uri != null)
                    hashCode = hashCode * 59 + this.Uri.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
