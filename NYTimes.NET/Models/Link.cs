using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "link")]
    public class Link
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Link" /> class.
        /// </summary>
        /// <param name="type">Type of asset linked to. Always article..</param>
        /// <param name="url">Review URL..</param>
        /// <param name="suggestedLinkText">Suggested text for link..</param>
        public Link(string type = default, string url = default, string suggestedLinkText = default)
        {
            this.Type = type;
            this.Url = url;
            this.SuggestedLinkText = suggestedLinkText;
        }

        /// <summary>
        /// Type of asset linked to. Always article.
        /// </summary>
        /// <value>Type of asset linked to. Always article.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Review URL.
        /// </summary>
        /// <value>Review URL.</value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Suggested text for link.
        /// </summary>
        /// <value>Suggested text for link.</value>
        [DataMember(Name = "suggested_link_text", EmitDefaultValue = false)]
        public string SuggestedLinkText { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Link {\n");
            sb.Append("  Type: ").Append(Type).Append('\n');
            sb.Append("  Url: ").Append(Url).Append('\n');
            sb.Append("  SuggestedLinkText: ").Append(SuggestedLinkText).Append('\n');
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
            return this.Equals(input as Link);
        }

        /// <summary>
        /// Returns true if Link instances are equal
        /// </summary>
        /// <param name="input">Instance of Link to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Link input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) &&
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) &&
                (
                    this.SuggestedLinkText == input.SuggestedLinkText ||
                    (this.SuggestedLinkText != null &&
                    this.SuggestedLinkText.Equals(input.SuggestedLinkText))
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
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.SuggestedLinkText != null)
                    hashCode = hashCode * 59 + this.SuggestedLinkText.GetHashCode();
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