using NYTimes.NET.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }

    
    public class Channel : IEquatable<Channel>, IValidatableObject
    {
        [XmlElement("link", Namespace = Constants.XmlNamespaces.Atom)]
        public AtomLinkWrapper AtomLinkWrapperObj { get; set; }

        public class AtomLinkWrapper
        {
            [XmlAttribute("href")]
            public string AtomLinkHrefAttr { get; set; }
        }

        /// <summary>
        /// Get Atomlink
        /// </summary>
        public string Atomlink
        {
            get => this.AtomLinkWrapperObj.AtomLinkHrefAttr;
        }

        /// <summary>
        /// Gets or Sets Copyright
        /// </summary>
        [XmlElement("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [XmlElement("image")]
        public ChannelImage Image { get; set; }

        /// <summary>
        /// Gets or Sets Articles
        /// </summary>
        [XmlElement("item")]
        public List<ChannelArticle> Articles { get; set; }

        /// <summary>
        /// Gets or Sets Language
        /// </summary>
        [XmlElement("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or Sets LastBuildDate
        /// </summary>
        [XmlElement("lastBuildDate")]
        public string LastBuildDate { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

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
            sb.Append("class Channel {\n");
            sb.Append("  Atomlink: ").Append(Atomlink).Append('\n');
            sb.Append("  Copyright: ").Append(Copyright).Append('\n');
            sb.Append("  Description: ").Append(Description).Append('\n');
            sb.Append("  Image: ").Append(Image).Append('\n');
            sb.Append("  Articles: ").Append(Articles).Append('\n');
            sb.Append("  Language: ").Append(Language).Append('\n');
            sb.Append("  LastBuildDate: ").Append(LastBuildDate).Append('\n');
            sb.Append("  Link: ").Append(Link).Append('\n');
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
            return this.Equals(input as Channel);
        }

        /// <summary>
        /// Returns true if Channel instances are equal
        /// </summary>
        /// <param name="input">Instance of Channel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Channel input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Atomlink == input.Atomlink ||
                    (this.Atomlink != null &&
                    this.Atomlink.Equals(input.Atomlink))
                ) &&
                (
                    this.Copyright == input.Copyright ||
                    (this.Copyright != null &&
                    this.Copyright.Equals(input.Copyright))
                ) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) &&
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) &&
                (
                    this.Articles == input.Articles ||
                    this.Articles != null &&
                    input.Articles != null &&
                    this.Articles.SequenceEqual(input.Articles)
                ) &&
                (
                    this.Language == input.Language ||
                    (this.Language != null &&
                    this.Language.Equals(input.Language))
                ) &&
                (
                    this.LastBuildDate == input.LastBuildDate ||
                    (this.LastBuildDate != null &&
                    this.LastBuildDate.Equals(input.LastBuildDate))
                ) &&
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
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
                if (this.Atomlink != null)
                    hashCode = hashCode * 59 + this.Atomlink.GetHashCode();
                if (this.Copyright != null)
                    hashCode = hashCode * 59 + this.Copyright.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.Articles != null)
                    hashCode = hashCode * 59 + this.Articles.GetHashCode();
                if (this.Language != null)
                    hashCode = hashCode * 59 + this.Language.GetHashCode();
                if (this.LastBuildDate != null)
                    hashCode = hashCode * 59 + this.LastBuildDate.GetHashCode();
                if (this.Link != null)
                    hashCode = hashCode * 59 + this.Link.GetHashCode();
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
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
