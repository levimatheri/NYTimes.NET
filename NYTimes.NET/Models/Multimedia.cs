/*
 * Archive
 *
 * The Archive API returns an array of NYT articles for a given month, going back to 1851.  Its response fields are the same as the Article Search API. The Archive API is very useful if you want to build your own database of NYT article metadata. You simply pass the API the year and month and it returns a JSON object with all articles for that month.  The response size can be large (~20mb).  ``` /{year}/{month}.json ```  ## Example Call ``` https://api.nytimes.com/svc/archive/v1/2019/1.json?api-key=yourkey ``` 
 *
 * The version of the OpenAPI document: 2.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Multimedia
    /// </summary>
    [DataContract(Name = "Multimedia")]
    public class Multimedia : IEquatable<Multimedia>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Multimedia" /> class.
        /// </summary>
        /// <param name="rank">rank.</param>
        /// <param name="subtype">subtype.</param>
        /// <param name="caption">caption.</param>
        /// <param name="credit">credit.</param>
        /// <param name="type">type.</param>
        /// <param name="url">url.</param>
        /// <param name="height">height.</param>
        /// <param name="width">width.</param>
        /// <param name="legacy">legacy.</param>
        /// <param name="cropName">cropName.</param>
        public Multimedia(int rank = default, string subtype = default, string caption = default, string credit = default,
            string type = default, string url = default, int height = default, int width = default, 
            MultimediaLegacy legacy = default, string cropName = default)
        {
            this.Rank = rank;
            this.Subtype = subtype;
            this.Caption = caption;
            this.Credit = credit;
            this.Type = type;
            this.Url = url;
            this.Height = height;
            this.Width = width;
            this.Legacy = legacy;
            this.CropName = cropName;
        }

        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name = "rank", EmitDefaultValue = false)]
        public int Rank { get; }

        /// <summary>
        /// Gets or Sets Subtype
        /// </summary>
        [DataMember(Name = "subtype", EmitDefaultValue = false)]
        public string Subtype { get; }

        /// <summary>
        /// Gets or Sets Caption
        /// </summary>
        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string Caption { get; }

        /// <summary>
        /// Gets or Sets Credit
        /// </summary>
        [DataMember(Name = "credit", EmitDefaultValue = false)]
        public string Credit { get; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public int Height { get; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        public int Width { get; }

        /// <summary>
        /// Gets or Sets Legacy
        /// </summary>
        [DataMember(Name = "legacy", EmitDefaultValue = false)]
        public MultimediaLegacy Legacy { get; }

        /// <summary>
        /// Gets or Sets CropName
        /// </summary>
        [DataMember(Name = "crop_name", EmitDefaultValue = false)]
        public string CropName { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Multimedia {\n");
            sb.Append("  Rank: ").Append(Rank).Append('\n');
            sb.Append("  Subtype: ").Append(Subtype).Append('\n');
            sb.Append("  Caption: ").Append(Caption).Append('\n');
            sb.Append("  Credit: ").Append(Credit).Append('\n');
            sb.Append("  Type: ").Append(Type).Append('\n');
            sb.Append("  Url: ").Append(Url).Append('\n');
            sb.Append("  Height: ").Append(Height).Append('\n');
            sb.Append("  Width: ").Append(Width).Append('\n');
            sb.Append("  Legacy: ").Append(Legacy).Append('\n');
            sb.Append("  CropName: ").Append(CropName).Append('\n');
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
            return this.Equals(input as Multimedia);
        }

        /// <summary>
        /// Returns true if Multimedia instances are equal
        /// </summary>
        /// <param name="input">Instance of Multimedia to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Multimedia input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Rank == input.Rank ||
                    this.Rank.Equals(input.Rank)
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
                    this.Credit == input.Credit ||
                    (this.Credit != null &&
                    this.Credit.Equals(input.Credit))
                ) && 
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
                    this.Height == input.Height ||
                    this.Height.Equals(input.Height)
                ) && 
                (
                    this.Width == input.Width ||
                    this.Width.Equals(input.Width)
                ) && 
                (
                    this.Legacy.Equals(input.Legacy) ||
                    (this.Legacy != null &&
                    this.Legacy.Equals(input.Legacy))
                ) && 
                (
                    this.CropName == input.CropName ||
                    (this.CropName != null &&
                    this.CropName.Equals(input.CropName))
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
                hashCode = hashCode * 59 + this.Rank.GetHashCode();
                if (this.Subtype != null)
                    hashCode = hashCode * 59 + this.Subtype.GetHashCode();
                if (this.Caption != null)
                    hashCode = hashCode * 59 + this.Caption.GetHashCode();
                if (this.Credit != null)
                    hashCode = hashCode * 59 + this.Credit.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                hashCode = hashCode * 59 + this.Height.GetHashCode();
                hashCode = hashCode * 59 + this.Width.GetHashCode();
                if (this.Legacy != null)
                    hashCode = hashCode * 59 + this.Legacy.GetHashCode();
                if (this.CropName != null)
                    hashCode = hashCode * 59 + this.CropName.GetHashCode();
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