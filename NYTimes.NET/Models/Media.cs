using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "media")]
    public class Media : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Media" /> class.
        /// </summary>
        /// <param name="type">Asset type (e.g. image)..</param>
        /// <param name="subtype">Asset subtype (e.g. photo)..</param>
        /// <param name="caption">Media caption..</param>
        /// <param name="copyright">Media credit..</param>
        /// <param name="approvedForSyndication">Whether media is approved for syndication..</param>
        /// <param name="mediaMetadata">Media metadata (url, width, height, ...)..</param>
        public Media(string type = default, string subtype = default, string caption = default, string copyright = default, bool approvedForSyndication = default, List<MediaMetadata> mediaMetadata = default)
        {
            this.Type = type;
            this.Subtype = subtype;
            this.Caption = caption;
            this.Copyright = copyright;
            this.ApprovedForSyndication = approvedForSyndication;
            this.MediaMetadata = mediaMetadata;
        }

        /// <summary>
        /// Asset type (e.g. image).
        /// </summary>
        /// <value>Asset type (e.g. image).</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; }

        /// <summary>
        /// Asset subtype (e.g. photo).
        /// </summary>
        /// <value>Asset subtype (e.g. photo).</value>
        [DataMember(Name = "subtype", EmitDefaultValue = false)]
        public string Subtype { get; }

        /// <summary>
        /// Media caption.
        /// </summary>
        /// <value>Media caption.</value>
        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string Caption { get; }

        /// <summary>
        /// Media credit.
        /// </summary>
        /// <value>Media credit.</value>
        [DataMember(Name = "copyright", EmitDefaultValue = false)]
        public string Copyright { get; }

        /// <summary>
        /// Whether media is approved for syndication.
        /// </summary>
        /// <value>Whether media is approved for syndication.</value>
        [DataMember(Name = "approved_for_syndication", EmitDefaultValue = true)]
        public bool ApprovedForSyndication { get; }

        /// <summary>
        /// Media metadata (url, width, height, ...).
        /// </summary>
        /// <value>Media metadata (url, width, height, ...).</value>
        [DataMember(Name = "media-metadata", EmitDefaultValue = false)]
        public List<MediaMetadata> MediaMetadata { get; }
    }
}
