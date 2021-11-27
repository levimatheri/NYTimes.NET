using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "media-metadata")]
    public class MediaMetadata : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaMetadata" /> class.
        /// </summary>
        /// <param name="url">Image&#39;s URL..</param>
        /// <param name="format">Image&#39;s crop name..</param>
        /// <param name="height">Image&#39;s height (e.g. 293)..</param>
        /// <param name="width">Image&#39;s width (e.g. 440)..</param>
        public MediaMetadata(string url = default, string format = default, int height = default, int width = default)
        {
            this.Url = url;
            this.Format = format;
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Image&#39;s URL.
        /// </summary>
        /// <value>Image&#39;s URL.</value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; }

        /// <summary>
        /// Image&#39;s crop name.
        /// </summary>
        /// <value>Image&#39;s crop name.</value>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public string Format { get; }

        /// <summary>
        /// Image&#39;s height (e.g. 293).
        /// </summary>
        /// <value>Image&#39;s height (e.g. 293).</value>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public int Height { get; }

        /// <summary>
        /// Image&#39;s width (e.g. 440).
        /// </summary>
        /// <value>Image&#39;s width (e.g. 440).</value>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        public int Width { get; }
    }
}