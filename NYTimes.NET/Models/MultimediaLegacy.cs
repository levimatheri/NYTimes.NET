using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// MultimediaLegacy
    /// </summary>
    [DataContract(Name = "multimedia_legacy")]
    public class MultimediaLegacy : ModelBase
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
    }
}
