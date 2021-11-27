using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Byline
    /// </summary>
    [DataContract(Name = "Byline")]
    public class Byline : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Byline" /> class.
        /// </summary>
        /// <param name="original">original.</param>
        /// <param name="person">person.</param>
        /// <param name="organization">organization.</param>
        public Byline(string original = default, List<Person> person = default, string organization = default)
        {
            this.Original = original;
            this.Person = person;
            this.Organization = organization;
        }

        /// <summary>
        /// Gets or Sets Original
        /// </summary>
        [DataMember(Name = "original", EmitDefaultValue = false)]
        public string Original { get; }

        /// <summary>
        /// Gets or Sets Person
        /// </summary>
        [DataMember(Name = "person", EmitDefaultValue = false)]
        public List<Person> Person { get; }

        /// <summary>
        /// Gets or Sets Organization
        /// </summary>
        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public string Organization { get; }
    }
}
