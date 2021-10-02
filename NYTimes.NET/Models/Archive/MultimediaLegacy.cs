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

namespace NYTimes.NET.Models.Archive
{
    /// <summary>
    /// MultimediaLegacy
    /// </summary>
    [DataContract(Name = "Multimedia_legacy")]
    public partial class MultimediaLegacy : IEquatable<MultimediaLegacy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultimediaLegacy" /> class.
        /// </summary>
        /// <param name="xlarge">xlarge.</param>
        /// <param name="xlargewidth">xlargewidth.</param>
        /// <param name="xlargeheight">xlargeheight.</param>
        public MultimediaLegacy(string xlarge = default(string), int xlargewidth = default(int), int xlargeheight = default(int))
        {
            this.Xlarge = xlarge;
            this.Xlargewidth = xlargewidth;
            this.Xlargeheight = xlargeheight;
        }

        /// <summary>
        /// Gets or Sets Xlarge
        /// </summary>
        [DataMember(Name = "xlarge", EmitDefaultValue = false)]
        public string Xlarge { get; }

        /// <summary>
        /// Gets or Sets Xlargewidth
        /// </summary>
        [DataMember(Name = "xlargewidth", EmitDefaultValue = false)]
        public int Xlargewidth { get; }

        /// <summary>
        /// Gets or Sets Xlargeheight
        /// </summary>
        [DataMember(Name = "xlargeheight", EmitDefaultValue = false)]
        public int Xlargeheight { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MultimediaLegacy {\n");
            sb.Append("  Xlarge: ").Append(Xlarge).Append('\n');
            sb.Append("  Xlargewidth: ").Append(Xlargewidth).Append('\n');
            sb.Append("  Xlargeheight: ").Append(Xlargeheight).Append('\n');
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
            return this.Equals(input as MultimediaLegacy);
        }

        /// <summary>
        /// Returns true if MultimediaLegacy instances are equal
        /// </summary>
        /// <param name="input">Instance of MultimediaLegacy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MultimediaLegacy input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Xlarge == input.Xlarge ||
                    (this.Xlarge != null &&
                    this.Xlarge.Equals(input.Xlarge))
                ) && 
                (
                    this.Xlargewidth == input.Xlargewidth ||
                    this.Xlargewidth.Equals(input.Xlargewidth)
                ) && 
                (
                    this.Xlargeheight == input.Xlargeheight ||
                    this.Xlargeheight.Equals(input.Xlargeheight)
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
                if (this.Xlarge != null)
                    hashCode = hashCode * 59 + this.Xlarge.GetHashCode();
                hashCode = hashCode * 59 + this.Xlargewidth.GetHashCode();
                hashCode = hashCode * 59 + this.Xlargeheight.GetHashCode();
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
