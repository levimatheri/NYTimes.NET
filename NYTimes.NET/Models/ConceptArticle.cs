using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class ConceptArticle : Article, IEquatable<ConceptArticle>, IValidatableObject
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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptArticle {\n");
            sb.Append("  Body: ").Append(Body).Append('\n');
            sb.Append("  Byline: ").Append(Byline).Append('\n');
            sb.Append("  Concepts: ").Append(Concepts).Append('\n');
            sb.Append("  Date: ").Append(Date).Append('\n');
            sb.Append("  DocumentType: ").Append(DocumentType).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  TypeOfMaterial: ").Append(TypeOfMaterial).Append('\n');
            sb.Append("  Url: ").Append(Url).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ConceptArticle);
        }

        /// <summary>
        /// Returns true if ConceptArticle instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptArticle to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptArticle input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Body == input.Body ||
                    (this.Body != null &&
                    this.Body.Equals(input.Body))
                ) &&
                (
                    this.Byline == input.Byline ||
                    (this.Byline != null &&
                    this.Byline.Equals(input.Byline))
                ) &&
                (
                    this.Concepts == input.Concepts ||
                    (this.Concepts != null &&
                    this.Concepts.Equals(input.Concepts))
                ) &&
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) &&
                (
                    this.DocumentType == input.DocumentType ||
                    (this.DocumentType != null &&
                    this.DocumentType.Equals(input.DocumentType))
                ) &&
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) &&
                (
                    this.TypeOfMaterial == input.TypeOfMaterial ||
                    (this.TypeOfMaterial != null &&
                    this.TypeOfMaterial.Equals(input.TypeOfMaterial))
                ) &&
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
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
                if (this.Body != null)
                    hashCode = hashCode * 59 + this.Body.GetHashCode();
                if (this.Byline != null)
                    hashCode = hashCode * 59 + this.Byline.GetHashCode();
                if (this.Concepts != null)
                    hashCode = hashCode * 59 + this.Concepts.GetHashCode();
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.DocumentType != null)
                    hashCode = hashCode * 59 + this.DocumentType.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.TypeOfMaterial != null)
                    hashCode = hashCode * 59 + this.TypeOfMaterial.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                return hashCode;
            }
        }
    }
}