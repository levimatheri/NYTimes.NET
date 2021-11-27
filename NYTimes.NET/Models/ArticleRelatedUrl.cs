using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "related_urls")]
    public class ArticleRelatedUrl : ModelBase
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
    }
}
