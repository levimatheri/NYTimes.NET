using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    public class ChannelImage : ModelBase
    {
        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
