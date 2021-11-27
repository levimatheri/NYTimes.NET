using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Headline
    /// </summary>
    [DataContract(Name = "headline")]
    public class Headline : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Headline" /> class.
        /// </summary>
        /// <param name="main">main.</param>
        /// <param name="kicker">kicker.</param>
        /// <param name="contentKicker">contentKicker.</param>
        /// <param name="printHeadline">printHeadline.</param>
        /// <param name="name">name.</param>
        /// <param name="seo">seo.</param>
        /// <param name="sub">sub.</param>
        public Headline(string main = default, string kicker = default, string contentKicker = default,
            string printHeadline = default, string name = default, string seo = default, string sub = default)
        {
            this.Main = main;
            this.Kicker = kicker;
            this.ContentKicker = contentKicker;
            this.PrintHeadline = printHeadline;
            this.Name = name;
            this.Seo = seo;
            this.Sub = sub;
        }

        /// <summary>
        /// Gets or Sets Main
        /// </summary>
        [DataMember(Name = "main", EmitDefaultValue = false)]
        public string Main { get; }

        /// <summary>
        /// Gets or Sets Kicker
        /// </summary>
        [DataMember(Name = "kicker", EmitDefaultValue = false)]
        public string Kicker { get; }

        /// <summary>
        /// Gets or Sets ContentKicker
        /// </summary>
        [DataMember(Name = "content_kicker", EmitDefaultValue = false)]
        public string ContentKicker { get; }

        /// <summary>
        /// Gets or Sets PrintHeadline
        /// </summary>
        [DataMember(Name = "print_headline", EmitDefaultValue = false)]
        public string PrintHeadline { get; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

        /// <summary>
        /// Gets or Sets Seo
        /// </summary>
        [DataMember(Name = "seo", EmitDefaultValue = false)]
        public string Seo { get; }

        /// <summary>
        /// Gets or Sets Sub
        /// </summary>
        [DataMember(Name = "sub", EmitDefaultValue = false)]
        public string Sub { get; }
    }
}
