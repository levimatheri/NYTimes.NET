using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    public class ChannelImage : IEquatable<ChannelImage>, IValidatableObject
    {
        ///// <summary>
        ///// Initializes a new instance of the <see cref="ChannelImage" /> class.
        ///// </summary>
        ///// <param name="link">link.</param>
        ///// <param name="title">title.</param>
        ///// <param name="url">url.</param>
        //public ChannelImage(string link = default(string), string title = default(string), string url = default(string))
        //{
        //    this.Link = link;
        //    this.Title = title;
        //    this.Url = url;
        //}

        public ChannelImage()
        {

        }

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
        /// Gets or Sets Url
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChannelImage {\n");
            sb.Append("  Link: ").Append(Link).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
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
            return this.Equals(input as ChannelImage);
        }

        /// <summary>
        /// Returns true if ChannelImage instances are equal
        /// </summary>
        /// <param name="input">Instance of ChannelImage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelImage input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
                ) &&
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
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
                int hashCode = 41;
                if (this.Link != null)
                    hashCode = hashCode * 59 + this.Link.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
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
