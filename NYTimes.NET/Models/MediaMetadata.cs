using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "media-metadata")]
    public class MediaMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaMetadata" /> class.
        /// </summary>
        /// <param name="url">Image&#39;s URL..</param>
        /// <param name="format">Image&#39;s crop name..</param>
        /// <param name="height">Image&#39;s height (e.g. 293)..</param>
        /// <param name="width">Image&#39;s width (e.g. 440)..</param>
        public MediaMetadata(string url = default, string format = default, int height = default, int width = default)
        {
            this.Url = url;
            this.Format = format;
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Image&#39;s URL.
        /// </summary>
        /// <value>Image&#39;s URL.</value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; }

        /// <summary>
        /// Image&#39;s crop name.
        /// </summary>
        /// <value>Image&#39;s crop name.</value>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public string Format { get; }

        /// <summary>
        /// Image&#39;s height (e.g. 293).
        /// </summary>
        /// <value>Image&#39;s height (e.g. 293).</value>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public int Height { get; }

        /// <summary>
        /// Image&#39;s width (e.g. 440).
        /// </summary>
        /// <value>Image&#39;s width (e.g. 440).</value>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        public int Width { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MediaMetadata {\n");
            sb.Append("  Url: ").Append(Url).Append('\n');
            sb.Append("  Format: ").Append(Format).Append('\n');
            sb.Append("  Height: ").Append(Height).Append('\n');
            sb.Append("  Width: ").Append(Width).Append('\n');
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
            return this.Equals(input as MediaMetadata);
        }

        /// <summary>
        /// Returns true if MediaMetadata instances are equal
        /// </summary>
        /// <param name="input">Instance of MediaMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MediaMetadata input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) &&
                (
                    this.Format == input.Format ||
                    (this.Format != null &&
                    this.Format.Equals(input.Format))
                ) &&
                (
                    this.Height == input.Height ||
                    this.Height.Equals(input.Height)
                ) &&
                (
                    this.Width == input.Width ||
                    this.Width.Equals(input.Width)
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
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.Format != null)
                    hashCode = hashCode * 59 + this.Format.GetHashCode();
                hashCode = hashCode * 59 + this.Height.GetHashCode();
                hashCode = hashCode * 59 + this.Width.GetHashCode();
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