using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "section")]
    public class Section : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Section" /> class.
        /// </summary>
        /// <param name="section">section.</param>
        /// <param name="displayName">displayName.</param>
        public Section(string section = default, string displayName = default)
        {
            this._Section = section;
            this.DisplayName = displayName;
        }

        /// <summary>
        /// Gets or Sets _Section
        /// </summary>
        [DataMember(Name = "section", EmitDefaultValue = false)]
        public string _Section { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; set; }
    }
}
