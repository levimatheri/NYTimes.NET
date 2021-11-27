using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Multimedia
    /// </summary>
    [DataContract(Name = "multimedia")]
    public class Multimedia : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Multimedia" /> class.
        /// </summary>
        /// <param name="rank">rank.</param>
        /// <param name="subtype">subtype.</param>
        /// <param name="caption">caption.</param>
        /// <param name="credit">credit.</param>
        /// <param name="type">type.</param>
        /// <param name="url">url.</param>
        /// <param name="height">height.</param>
        /// <param name="width">width.</param>
        /// <param name="legacy">legacy.</param>
        /// <param name="cropName">cropName.</param>
        /// <param name="src">src.</param>
        public Multimedia(int rank = default, string subtype = default, string caption = default, string credit = default,
            string type = default, string url = default, int height = default, int width = default, 
            MultimediaLegacy legacy = default, string cropName = default, string format = default, string copyright = default)
        {
            this.Rank = rank;
            this.Subtype = subtype;
            this.Caption = caption;
            this.Credit = credit;
            this.Type = type;
            this.Url = url;
            this.Height = height;
            this.Width = width;
            this.Legacy = legacy;
            this.CropName = cropName;
            this.Format = format;
            this.Copyright = copyright;
        }

        /// <summary>
        /// URL of image.
        /// </summary>
        /// <value>URL of image.</value>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public string Format { get; set; }

        /// <summary>
        /// URL of image.
        /// </summary>
        /// <value>URL of image.</value>
        [DataMember(Name = "copyright", EmitDefaultValue = false)]
        public string Copyright { get; set; }

        /// <summary>
        /// URL of image.
        /// </summary>
        /// <value>URL of image.</value>
        [DataMember(Name = "src", EmitDefaultValue = false)]
        public string Src { get; set; }

        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name = "rank", EmitDefaultValue = false)]
        public int Rank { get; }

        /// <summary>
        /// Gets or Sets Subtype
        /// </summary>
        [DataMember(Name = "subtype", EmitDefaultValue = false)]
        public string Subtype { get; }

        /// <summary>
        /// Gets or Sets Caption
        /// </summary>
        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string Caption { get; }

        /// <summary>
        /// Gets or Sets Credit
        /// </summary>
        [DataMember(Name = "credit", EmitDefaultValue = false)]
        public string Credit { get; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public int Height { get; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        public int Width { get; }

        /// <summary>
        /// Gets or Sets Legacy
        /// </summary>
        [DataMember(Name = "legacy", EmitDefaultValue = false)]
        public MultimediaLegacy Legacy { get; }

        /// <summary>
        /// Gets or Sets CropName
        /// </summary>
        [DataMember(Name = "crop_name", EmitDefaultValue = false)]
        public string CropName { get; }
    }
}
