using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class NewsArticle : Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Article" /> class.
        /// </summary>
        /// <param name="section">section.</param>
        /// <param name="subsection">subsection.</param>
        /// <param name="title">title.</param>
        /// <param name="_abstract">_abstract.</param>
        /// <param name="url">url.</param>
        /// <param name="shortUrl">shortUrl.</param>
        /// <param name="byline">byline.</param>
        /// <param name="thumbnailStandard">thumbnailStandard.</param>
        /// <param name="itemType">itemType.</param>
        /// <param name="source">source.</param>
        /// <param name="updatedDate">updatedDate.</param>
        /// <param name="createdDate">createdDate.</param>
        /// <param name="publishedDate">publishedDate.</param>
        /// <param name="materialTypeFacet">materialTypeFacet.</param>
        /// <param name="kicker">kicker.</param>
        /// <param name="headline">headline.</param>
        /// <param name="desFacet">desFacet.</param>
        /// <param name="orgFacet">orgFacet.</param>
        /// <param name="perFacet">perFacet.</param>
        /// <param name="geoFacet">geoFacet.</param>
        /// <param name="blogName">blogName.</param>
        /// <param name="relatedUrls">relatedUrls.</param>
        /// <param name="multimedia">multimedia.</param>
        public NewsArticle(string section = default, string subsection = default, string title = default, string _abstract = default, string url = default, string shortUrl = default, string byline = default, string thumbnailStandard = default, string itemType = default, 
            string source = default, string updatedDate = default, string createdDate = default, string publishedDate = default, string materialTypeFacet = default, string kicker = default, string headline = default, List<string> desFacet = default, List<string> orgFacet = default, 
            List<string> perFacet = default, List<string> geoFacet = default, string blogName = default, List<ArticleRelatedUrl> relatedUrls = default, List<Multimedia> multimedia = default)
            : base(webUrl: url, source: source, headline: new Headline(main: headline), pubDate: publishedDate, documentType: itemType, byline: new Byline(original: byline), typeOfMaterial: materialTypeFacet, multimedia: multimedia)
        {
            this.Section = section;
            this.Subsection = subsection;
            this.Title = title;
            this.Abstract = _abstract;
            this.Url = url;
            this.ShortUrl = shortUrl;
            this.ThumbnailStandard = thumbnailStandard;
            this.ItemType = itemType;
            this.UpdatedDate = updatedDate;
            this.CreatedDate = createdDate;
            this.PublishedDate = publishedDate;
            this.MaterialTypeFacet = materialTypeFacet;
            this.Kicker = kicker;
            this.DesFacet = desFacet;
            this.OrgFacet = orgFacet;
            this.PerFacet = perFacet;
            this.GeoFacet = geoFacet;
            this.BlogName = blogName;
            this.RelatedUrls = relatedUrls;
        }

        /// <summary>
        /// Gets or Sets Section
        /// </summary>
        [DataMember(Name = "section", EmitDefaultValue = false)]
        public string Section { get; set; }

        /// <summary>
        /// Gets or Sets Subsection
        /// </summary>
        [DataMember(Name = "subsection", EmitDefaultValue = false)]
        public string Subsection { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Abstract
        /// </summary>
        [DataMember(Name = "abstract", EmitDefaultValue = false)]
        public string Abstract { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets ShortUrl
        /// </summary>
        [DataMember(Name = "short_url", EmitDefaultValue = false)]
        public string ShortUrl { get; set; }

        /// <summary>
        /// Gets or Sets ThumbnailStandard
        /// </summary>
        [DataMember(Name = "thumbnail_standard", EmitDefaultValue = false)]
        public string ThumbnailStandard { get; set; }

        /// <summary>
        /// Gets or Sets ItemType
        /// </summary>
        [DataMember(Name = "item_type", EmitDefaultValue = false)]
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedDate
        /// </summary>
        [DataMember(Name = "updated_date", EmitDefaultValue = false)]
        public string UpdatedDate { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [DataMember(Name = "created_date", EmitDefaultValue = false)]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets PublishedDate
        /// </summary>
        [DataMember(Name = "published_date", EmitDefaultValue = false)]
        public string PublishedDate { get; set; }

        /// <summary>
        /// Gets or Sets MaterialTypeFacet
        /// </summary>
        [DataMember(Name = "material_type_facet", EmitDefaultValue = false)]
        public string MaterialTypeFacet { get; set; }

        /// <summary>
        /// Gets or Sets Kicker
        /// </summary>
        [DataMember(Name = "kicker", EmitDefaultValue = false)]
        public string Kicker { get; set; }

        /// <summary>
        /// Gets or Sets DesFacet
        /// </summary>
        [DataMember(Name = "des_facet", EmitDefaultValue = false)]
        public List<string> DesFacet { get; set; }

        /// <summary>
        /// Gets or Sets OrgFacet
        /// </summary>
        [DataMember(Name = "org_facet", EmitDefaultValue = false)]
        public List<string> OrgFacet { get; set; }

        /// <summary>
        /// Gets or Sets PerFacet
        /// </summary>
        [DataMember(Name = "per_facet", EmitDefaultValue = false)]
        public List<string> PerFacet { get; set; }

        /// <summary>
        /// Gets or Sets GeoFacet
        /// </summary>
        [DataMember(Name = "geo_facet", EmitDefaultValue = false)]
        public List<string> GeoFacet { get; set; }

        /// <summary>
        /// Gets or Sets BlogName
        /// </summary>
        [DataMember(Name = "blog_name", EmitDefaultValue = false)]
        public string BlogName { get; set; }

        /// <summary>
        /// Gets or Sets RelatedUrls
        /// </summary>
        [DataMember(Name = "related_urls", EmitDefaultValue = false)]
        public List<ArticleRelatedUrl> RelatedUrls { get; set; }
    }
}
