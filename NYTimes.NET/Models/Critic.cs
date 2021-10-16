using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class Critic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Critic" /> class.
        /// </summary>
        /// <param name="displayName">Critic&#39;s name (e.g. A. O. Scott)..</param>
        /// <param name="sortName">Field used when sorting..</param>
        /// <param name="status">Status of the critic (full-time, part-time, or null)..</param>
        /// <param name="bio">Short bio of critic..</param>
        /// <param name="seoName">Critic name for URL (spaces are replaced with hyphens and periods removed)..</param>
        /// <param name="multimedia">multimedia.</param>
        public Critic(string displayName = default, string sortName = default, string status = default, string bio = default, string seoName = default, CriticMultimediaWrapper multimedia = default)
        {
            this.DisplayName = displayName;
            this.SortName = sortName;
            this.Status = status;
            this.Bio = bio;
            this.SeoName = seoName;
            this.Multimedia = multimedia;
        }

        /// <summary>
        /// Critic&#39;s name (e.g. A. O. Scott).
        /// </summary>
        /// <value>Critic&#39;s name (e.g. A. O. Scott).</value>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Field used when sorting.
        /// </summary>
        /// <value>Field used when sorting.</value>
        [DataMember(Name = "sort_name", EmitDefaultValue = false)]
        public string SortName { get; set; }

        /// <summary>
        /// Status of the critic (full-time, part-time, or null).
        /// </summary>
        /// <value>Status of the critic (full-time, part-time, or null).</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// Short bio of critic.
        /// </summary>
        /// <value>Short bio of critic.</value>
        [DataMember(Name = "bio", EmitDefaultValue = false)]
        public string Bio { get; set; }

        /// <summary>
        /// Critic name for URL (spaces are replaced with hyphens and periods removed).
        /// </summary>
        /// <value>Critic name for URL (spaces are replaced with hyphens and periods removed).</value>
        [DataMember(Name = "seo-name", EmitDefaultValue = false)]
        public string SeoName { get; set; }

        /// <summary>
        /// Gets or Sets Multimedia
        /// </summary>
        [DataMember(Name = "multimedia", EmitDefaultValue = false)]
        public CriticMultimediaWrapper Multimedia { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Critic {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  SortName: ").Append(SortName).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Bio: ").Append(Bio).Append("\n");
            sb.Append("  SeoName: ").Append(SeoName).Append("\n");
            sb.Append("  Multimedia: ").Append(Multimedia).Append("\n");
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
            return this.Equals(input as Critic);
        }

        /// <summary>
        /// Returns true if Critic instances are equal
        /// </summary>
        /// <param name="input">Instance of Critic to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Critic input)
        {
            if (input == null)
                return false;

            return
                (
                    this.DisplayName == input.DisplayName ||
                    (this.DisplayName != null &&
                    this.DisplayName.Equals(input.DisplayName))
                ) &&
                (
                    this.SortName == input.SortName ||
                    (this.SortName != null &&
                    this.SortName.Equals(input.SortName))
                ) &&
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) &&
                (
                    this.Bio == input.Bio ||
                    (this.Bio != null &&
                    this.Bio.Equals(input.Bio))
                ) &&
                (
                    this.SeoName == input.SeoName ||
                    (this.SeoName != null &&
                    this.SeoName.Equals(input.SeoName))
                ) &&
                (
                    this.Multimedia == input.Multimedia ||
                    (this.Multimedia != null &&
                    this.Multimedia.Equals(input.Multimedia))
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
                if (this.DisplayName != null)
                    hashCode = hashCode * 59 + this.DisplayName.GetHashCode();
                if (this.SortName != null)
                    hashCode = hashCode * 59 + this.SortName.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Bio != null)
                    hashCode = hashCode * 59 + this.Bio.GetHashCode();
                if (this.SeoName != null)
                    hashCode = hashCode * 59 + this.SeoName.GetHashCode();
                if (this.Multimedia != null)
                    hashCode = hashCode * 59 + this.Multimedia.GetHashCode();
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
