using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class Critic : ModelBase
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
    }
}
