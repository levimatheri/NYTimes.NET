using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "related_urls")]
    public class ArticleRelatedUrl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleRelatedUrl" /> class.
        /// </summary>
        /// <param name="suggestedLinkText">suggestedLinkText.</param>
        /// <param name="url">url.</param>
        public ArticleRelatedUrl(string suggestedLinkText = default(string), string url = default(string))
        {
            this.SuggestedLinkText = suggestedLinkText;
            this.Url = url;
        }

        /// <summary>
        /// Gets or Sets SuggestedLinkText
        /// </summary>
        [DataMember(Name = "suggested_link_text", EmitDefaultValue = false)]
        public string SuggestedLinkText { get; set; }

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
            sb.Append("class ArticleRelatedUrl {\n");
            sb.Append("  SuggestedLinkText: ").Append(SuggestedLinkText).Append('\n');
            sb.Append("  Url: ").Append(Url).Append('\n');
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
            return this.Equals(input as ArticleRelatedUrl);
        }

        /// <summary>
        /// Returns true if ArticleRelatedUrl instances are equal
        /// </summary>
        /// <param name="input">Instance of ArticleRelatedUrl to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticleRelatedUrl input)
        {
            if (input == null)
                return false;

            return
                (
                    this.SuggestedLinkText == input.SuggestedLinkText ||
                    (this.SuggestedLinkText != null &&
                    this.SuggestedLinkText.Equals(input.SuggestedLinkText))
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
                if (this.SuggestedLinkText != null)
                    hashCode = hashCode * 59 + this.SuggestedLinkText.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
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
