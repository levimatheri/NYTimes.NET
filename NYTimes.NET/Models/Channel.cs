using NYTimes.NET.Clients;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NYTimes.NET.Models
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }

    public class Channel : ModelBase
    {
        [XmlElement("link", Namespace = Constants.XmlNamespaces.Atom)]
        public AtomLinkWrapper AtomLinkWrapperObj { get; set; }

        public class AtomLinkWrapper
        {
            [XmlAttribute("href")]
            public string AtomLinkHrefAttr { get; set; }
        }

        /// <summary>
        /// Get Atomlink
        /// </summary>
        public string Atomlink
        {
            get => this.AtomLinkWrapperObj?.AtomLinkHrefAttr;
        }

        /// <summary>
        /// Gets or Sets Copyright
        /// </summary>
        [XmlElement("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [XmlElement("image")]
        public ChannelImage Image { get; set; }

        /// <summary>
        /// Gets or Sets Articles
        /// </summary>
        [XmlElement("item")]
        public List<ChannelArticle> Articles { get; set; }

        /// <summary>
        /// Gets or Sets Language
        /// </summary>
        [XmlElement("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or Sets LastBuildDate
        /// </summary>
        [XmlElement("lastBuildDate")]
        public string LastBuildDate { get; set; }

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
    }
}
