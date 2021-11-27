using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Isbns
    /// </summary>
    public class Isbn : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Isbn" /> class.
        /// </summary>
        /// <param name="isbn10">isbn10.</param>
        /// <param name="isbn13">isbn13.</param>
        public Isbn(string isbn10 = default, string isbn13 = default)
        {
            this.Isbn10 = isbn10;
            this.Isbn13 = isbn13;
        }

        /// <summary>
        /// Gets or Sets Isbn10
        /// </summary>
        [DataMember(Name = "isbn10", EmitDefaultValue = false)]
        public string Isbn10 { get; }

        /// <summary>
        /// Gets or Sets Isbn13
        /// </summary>
        [DataMember(Name = "isbn13", EmitDefaultValue = false)]
        public string Isbn13 { get; }
    }
}