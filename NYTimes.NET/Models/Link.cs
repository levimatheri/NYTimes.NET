using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "link")]
    public class Link : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Link" /> class.
        /// </summary>
        /// <param name="type">Type of asset linked to. Always article.</param>
        /// <param name="url">Review URL.</param>
        /// <param name="suggestedLinkText">Suggested text for link.</param>
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
    }
}