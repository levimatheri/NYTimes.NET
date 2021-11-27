using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "multimedia")]
    public class CriticMultimediaWrapper : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CriticMultimediaWrapper" /> class.
        /// </summary>
        /// <param name="resource">resource.</param>
        public CriticMultimediaWrapper(Multimedia resource = default)
        {
            this.Resource = resource;
        }

        /// <summary>
        /// Gets or Sets Resource
        /// </summary>
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        public Multimedia Resource { get; set; }
    }
}
