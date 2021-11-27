using NYTimes.NET.Clients;
using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    public class ChannelArticle : ModelBase
    {
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Creator
        /// </summary>
        [XmlElement("creator", Namespace = Constants.XmlNamespaces.Dc)]
        public string Creator { get; set; }

        /// <summary>
        /// Gets or Sets Guid
        /// </summary>
        [XmlElement("guid")]
        public string Guid { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or Sets MediaContent
        /// </summary>
        [XmlElement("content", Namespace = Constants.XmlNamespaces.Media)]
        public MediaContentWrapper MediaContentWrapperObj { get; set; }

        public class MediaContentWrapper
        {
            [XmlAttribute("url")]
            public string MediaContentUrl { get; set; }
        }

        public string MediaContent
        {
            get => this.MediaContentWrapperObj?.MediaContentUrl;
        }

        /// <summary>
        /// Gets or Sets MediaCredit
        /// </summary>
        [XmlElement("credit", Namespace = Constants.XmlNamespaces.Media)]
        public string MediaCredit { get; set; }

        /// <summary>
        /// Gets or Sets MediaDescription
        /// </summary>
        [XmlElement("description", Namespace = Constants.XmlNamespaces.Media)]
        public string MediaDescription { get; set; } 

        /// <summary>
        /// Gets or Sets PubDate
        /// </summary>
        [XmlElement("pubDate")]
        public string PubDate { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
