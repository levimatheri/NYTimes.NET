using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "media")]
    public class Media
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Media" /> class.
        /// </summary>
        /// <param name="type">Asset type (e.g. image)..</param>
        /// <param name="subtype">Asset subtype (e.g. photo)..</param>
        /// <param name="caption">Media caption..</param>
        /// <param name="copyright">Media credit..</param>
        /// <param name="approvedForSyndication">Whether media is approved for syndication..</param>
        /// <param name="mediaMetadata">Media metadata (url, width, height, ...)..</param>
        public Media(string type = default, string subtype = default, string caption = default, string copyright = default, bool approvedForSyndication = default, List<MediaMetadata> mediaMetadata = default)
        {
            this.Type = type;
            this.Subtype = subtype;
            this.Caption = caption;
            this.Copyright = copyright;
            this.ApprovedForSyndication = approvedForSyndication;
            this.MediaMetadata = mediaMetadata;
        }

        /// <summary>
        /// Asset type (e.g. image).
        /// </summary>
        /// <value>Asset type (e.g. image).</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; }

        /// <summary>
        /// Asset subtype (e.g. photo).
        /// </summary>
        /// <value>Asset subtype (e.g. photo).</value>
        [DataMember(Name = "subtype", EmitDefaultValue = false)]
        public string Subtype { get; }

        /// <summary>
        /// Media caption.
        /// </summary>
        /// <value>Media caption.</value>
        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string Caption { get; }

        /// <summary>
        /// Media credit.
        /// </summary>
        /// <value>Media credit.</value>
        [DataMember(Name = "copyright", EmitDefaultValue = false)]
        public string Copyright { get; }

        /// <summary>
        /// Whether media is approved for syndication.
        /// </summary>
        /// <value>Whether media is approved for syndication.</value>
        [DataMember(Name = "approved_for_syndication", EmitDefaultValue = true)]
        public bool ApprovedForSyndication { get; }

        /// <summary>
        /// Media metadata (url, width, height, ...).
        /// </summary>
        /// <value>Media metadata (url, width, height, ...).</value>
        [DataMember(Name = "media-metadata", EmitDefaultValue = false)]
        public List<MediaMetadata> MediaMetadata { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Media {\n");
            sb.Append("  Type: ").Append(Type).Append('\n');
            sb.Append("  Subtype: ").Append(Subtype).Append('\n');
            sb.Append("  Caption: ").Append(Caption).Append('\n');
            sb.Append("  Copyright: ").Append(Copyright).Append('\n');
            sb.Append("  ApprovedForSyndication: ").Append(ApprovedForSyndication).Append('\n');
            sb.Append("  MediaMetadata: ").Append(MediaMetadata).Append('\n');
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
            return this.Equals(input as Media);
        }

        /// <summary>
        /// Returns true if Media instances are equal
        /// </summary>
        /// <param name="input">Instance of Media to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Media input)
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
                    this.Subtype == input.Subtype ||
                    (this.Subtype != null &&
                    this.Subtype.Equals(input.Subtype))
                ) &&
                (
                    this.Caption == input.Caption ||
                    (this.Caption != null &&
                    this.Caption.Equals(input.Caption))
                ) &&
                (
                    this.Copyright == input.Copyright ||
                    (this.Copyright != null &&
                    this.Copyright.Equals(input.Copyright))
                ) &&
                (
                    this.ApprovedForSyndication == input.ApprovedForSyndication ||
                    this.ApprovedForSyndication.Equals(input.ApprovedForSyndication)
                ) &&
                (
                    this.MediaMetadata == input.MediaMetadata ||
                    this.MediaMetadata != null &&
                    input.MediaMetadata != null &&
                    this.MediaMetadata.SequenceEqual(input.MediaMetadata)
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
                if (this.Subtype != null)
                    hashCode = hashCode * 59 + this.Subtype.GetHashCode();
                if (this.Caption != null)
                    hashCode = hashCode * 59 + this.Caption.GetHashCode();
                if (this.Copyright != null)
                    hashCode = hashCode * 59 + this.Copyright.GetHashCode();
                hashCode = hashCode * 59 + this.ApprovedForSyndication.GetHashCode();
                if (this.MediaMetadata != null)
                    hashCode = hashCode * 59 + this.MediaMetadata.GetHashCode();
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
