using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Keyword
    /// </summary>
    [DataContract(Name = "keyword")]
    public class Keyword : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Keyword" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="value">value.</param>
        /// <param name="rank">rank.</param>
        /// <param name="major">major.</param>
        public Keyword(string name = default, string value = default, int rank = default, string major = default)
        {
            this.Name = name;
            this.Value = value;
            this.Rank = rank;
            this.Major = major;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; }

        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name = "rank", EmitDefaultValue = false)]
        public int Rank { get; }

        /// <summary>
        /// Gets or Sets Major
        /// </summary>
        [DataMember(Name = "major", EmitDefaultValue = false)]
        public string Major { get; }
    }
}
