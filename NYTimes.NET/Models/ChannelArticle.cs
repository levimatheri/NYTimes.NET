using NYTimes.NET.Clients;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    public class ChannelArticle
    {
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Creator
        /// </summary>
        [XmlElement("creator", Namespace = Constants.XmlNamespaces.Dc)]
        public string Creator { get; set; }

        /// <summary>
        /// Gets or Sets Guid
        /// </summary>
        [XmlElement("guid")]
        public string Guid { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or Sets MediaContent
        /// </summary>
        [XmlElement("content", Namespace = Constants.XmlNamespaces.Media)]
        public MediaContentWrapper MediaContentWrapperObj { get; set; }

        public class MediaContentWrapper
        {
            [XmlAttribute("url")]
            public string MediaContentUrl { get; set; }
        }

        public string MediaContent
        {
            get => this.MediaContentWrapperObj.MediaContentUrl;
        }

        /// <summary>
        /// Gets or Sets MediaCredit
        /// </summary>
        [XmlElement("credit", Namespace = Constants.XmlNamespaces.Media)]
        public string MediaCredit { get; set; }

        /// <summary>
        /// Gets or Sets MediaDescription
        /// </summary>
        [XmlElement("description", Namespace = Constants.XmlNamespaces.Media)]
        public string MediaDescription { get; set; } 

        /// <summary>
        /// Gets or Sets PubDate
        /// </summary>
        [XmlElement("pubDate")]
        public string PubDate { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Item {\n");
            sb.Append("  Category: ").Append(Category).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Creator: ").Append(Creator).Append('\n');
            sb.Append("  Guid: ").Append(Guid).Append('\n');
            sb.Append("  Link: ").Append(Link).Append('\n');
            sb.Append("  MediaContent: ").Append(MediaContent).Append('\n');
            sb.Append("  MediaCredit: ").Append(MediaCredit).Append('\n');
            sb.Append("  MediaDescription: ").Append(MediaDescription).Append('\n');
            sb.Append("  PubDate: ").Append(PubDate).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
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
            return this.Equals(input as ChannelArticle);
        }

        /// <summary>
        /// Returns true if Item instances are equal
        /// </summary>
        /// <param name="input">Instance of Item to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelArticle input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) &&
                (
                    this.Creator == input.Creator ||
                    (this.Creator != null &&
                    this.Creator.Equals(input.Creator))
                ) &&
                (
                    this.Guid == input.Guid ||
                    (this.Guid != null &&
                    this.Guid.Equals(input.Guid))
                ) &&
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
                ) &&
                (
                    this.MediaContent == input.MediaContent ||
                    (this.MediaContent != null &&
                    this.MediaContent.Equals(input.MediaContent))
                ) &&
                (
                    this.MediaCredit == input.MediaCredit ||
                    (this.MediaCredit != null &&
                    this.MediaCredit.Equals(input.MediaCredit))
                ) &&
                (
                    this.MediaDescription == input.MediaDescription ||
                    (this.MediaDescription != null &&
                    this.MediaDescription.Equals(input.MediaDescription))
                ) &&
                (
                    this.PubDate == input.PubDate ||
                    (this.PubDate != null &&
                    this.PubDate.Equals(input.PubDate))
                ) &&
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
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
                int hashCode = 41;
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Creator != null)
                    hashCode = hashCode * 59 + this.Creator.GetHashCode();
                if (this.Guid != null)
                    hashCode = hashCode * 59 + this.Guid.GetHashCode();
                if (this.Link != null)
                    hashCode = hashCode * 59 + this.Link.GetHashCode();
                if (this.MediaContent != null)
                    hashCode = hashCode * 59 + this.MediaContent.GetHashCode();
                if (this.MediaCredit != null)
                    hashCode = hashCode * 59 + this.MediaCredit.GetHashCode();
                if (this.MediaDescription != null)
                    hashCode = hashCode * 59 + this.MediaDescription.GetHashCode();
                if (this.PubDate != null)
                    hashCode = hashCode * 59 + this.PubDate.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
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
