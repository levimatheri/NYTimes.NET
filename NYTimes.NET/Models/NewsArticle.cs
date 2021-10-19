using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class NewsArticle : Article, IEquatable<NewsArticle>, IValidatableObject
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


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Article {\n");
            sb.Append("  Section: ").Append(Section).Append('\n');
            sb.Append("  Subsection: ").Append(Subsection).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  Abstract: ").Append(Abstract).Append('\n');
            sb.Append("  Url: ").Append(Url).Append('\n');
            sb.Append("  ShortUrl: ").Append(ShortUrl).Append('\n');
            sb.Append("  Byline: ").Append(Byline).Append('\n');
            sb.Append("  ThumbnailStandard: ").Append(ThumbnailStandard).Append('\n');
            sb.Append("  ItemType: ").Append(ItemType).Append('\n');
            sb.Append("  Source: ").Append(Source).Append('\n');
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append('\n');
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append('\n');
            sb.Append("  PublishedDate: ").Append(PublishedDate).Append('\n');
            sb.Append("  MaterialTypeFacet: ").Append(MaterialTypeFacet).Append('\n');
            sb.Append("  Kicker: ").Append(Kicker).Append('\n');
            sb.Append("  Headline: ").Append(Headline).Append('\n');
            sb.Append("  DesFacet: ").Append(DesFacet).Append('\n');
            sb.Append("  OrgFacet: ").Append(OrgFacet).Append('\n');
            sb.Append("  PerFacet: ").Append(PerFacet).Append('\n');
            sb.Append("  GeoFacet: ").Append(GeoFacet).Append('\n');
            sb.Append("  BlogName: ").Append(BlogName).Append('\n');
            sb.Append("  RelatedUrls: ").Append(RelatedUrls).Append('\n');
            sb.Append("  Multimedia: ").Append(Multimedia).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Article);
        }

        /// <summary>
        /// Returns true if Article instances are equal
        /// </summary>
        /// <param name="input">Instance of Article to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NewsArticle input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Section == input.Section ||
                    (this.Section != null &&
                    this.Section.Equals(input.Section))
                ) &&
                (
                    this.Subsection == input.Subsection ||
                    (this.Subsection != null &&
                    this.Subsection.Equals(input.Subsection))
                ) &&
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) &&
                (
                    this.Abstract == input.Abstract ||
                    (this.Abstract != null &&
                    this.Abstract.Equals(input.Abstract))
                ) &&
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) &&
                (
                    this.ShortUrl == input.ShortUrl ||
                    (this.ShortUrl != null &&
                    this.ShortUrl.Equals(input.ShortUrl))
                ) &&
                (
                    this.Byline == input.Byline ||
                    (this.Byline != null &&
                    this.Byline.Equals(input.Byline))
                ) &&
                (
                    this.ThumbnailStandard == input.ThumbnailStandard ||
                    (this.ThumbnailStandard != null &&
                    this.ThumbnailStandard.Equals(input.ThumbnailStandard))
                ) &&
                (
                    this.ItemType == input.ItemType ||
                    (this.ItemType != null &&
                    this.ItemType.Equals(input.ItemType))
                ) &&
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) &&
                (
                    this.UpdatedDate == input.UpdatedDate ||
                    (this.UpdatedDate != null &&
                    this.UpdatedDate.Equals(input.UpdatedDate))
                ) &&
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) &&
                (
                    this.PublishedDate == input.PublishedDate ||
                    (this.PublishedDate != null &&
                    this.PublishedDate.Equals(input.PublishedDate))
                ) &&
                (
                    this.MaterialTypeFacet == input.MaterialTypeFacet ||
                    (this.MaterialTypeFacet != null &&
                    this.MaterialTypeFacet.Equals(input.MaterialTypeFacet))
                ) &&
                (
                    this.Kicker == input.Kicker ||
                    (this.Kicker != null &&
                    this.Kicker.Equals(input.Kicker))
                ) &&
                (
                    this.Headline == input.Headline ||
                    (this.Headline != null &&
                    this.Headline.Equals(input.Headline))
                ) &&
                (
                    this.DesFacet == input.DesFacet ||
                    this.DesFacet != null &&
                    input.DesFacet != null &&
                    this.DesFacet.SequenceEqual(input.DesFacet)
                ) &&
                (
                    this.OrgFacet == input.OrgFacet ||
                    (this.OrgFacet != null &&
                    this.OrgFacet.Equals(input.OrgFacet))
                ) &&
                (
                    this.PerFacet == input.PerFacet ||
                    this.PerFacet != null &&
                    input.PerFacet != null &&
                    this.PerFacet.SequenceEqual(input.PerFacet)
                ) &&
                (
                    this.GeoFacet == input.GeoFacet ||
                    this.GeoFacet != null &&
                    input.GeoFacet != null &&
                    this.GeoFacet.SequenceEqual(input.GeoFacet)
                ) &&
                (
                    this.BlogName == input.BlogName ||
                    (this.BlogName != null &&
                    this.BlogName.Equals(input.BlogName))
                ) &&
                (
                    this.RelatedUrls == input.RelatedUrls ||
                    this.RelatedUrls != null &&
                    input.RelatedUrls != null &&
                    this.RelatedUrls.SequenceEqual(input.RelatedUrls)
                ) &&
                (
                    this.Multimedia == input.Multimedia ||
                    this.Multimedia != null &&
                    input.Multimedia != null &&
                    this.Multimedia.SequenceEqual(input.Multimedia)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (this.Section != null)
                    hashCode = hashCode * 59 + this.Section.GetHashCode();
                if (this.Subsection != null)
                    hashCode = hashCode * 59 + this.Subsection.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Abstract != null)
                    hashCode = hashCode * 59 + this.Abstract.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.ShortUrl != null)
                    hashCode = hashCode * 59 + this.ShortUrl.GetHashCode();
                if (this.Byline != null)
                    hashCode = hashCode * 59 + this.Byline.GetHashCode();
                if (this.ThumbnailStandard != null)
                    hashCode = hashCode * 59 + this.ThumbnailStandard.GetHashCode();
                if (this.ItemType != null)
                    hashCode = hashCode * 59 + this.ItemType.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.UpdatedDate != null)
                    hashCode = hashCode * 59 + this.UpdatedDate.GetHashCode();
                if (this.CreatedDate != null)
                    hashCode = hashCode * 59 + this.CreatedDate.GetHashCode();
                if (this.PublishedDate != null)
                    hashCode = hashCode * 59 + this.PublishedDate.GetHashCode();
                if (this.MaterialTypeFacet != null)
                    hashCode = hashCode * 59 + this.MaterialTypeFacet.GetHashCode();
                if (this.Kicker != null)
                    hashCode = hashCode * 59 + this.Kicker.GetHashCode();
                if (this.Headline != null)
                    hashCode = hashCode * 59 + this.Headline.GetHashCode();
                if (this.DesFacet != null)
                    hashCode = hashCode * 59 + this.DesFacet.GetHashCode();
                if (this.OrgFacet != null)
                    hashCode = hashCode * 59 + this.OrgFacet.GetHashCode();
                if (this.PerFacet != null)
                    hashCode = hashCode * 59 + this.PerFacet.GetHashCode();
                if (this.GeoFacet != null)
                    hashCode = hashCode * 59 + this.GeoFacet.GetHashCode();
                if (this.BlogName != null)
                    hashCode = hashCode * 59 + this.BlogName.GetHashCode();
                if (this.RelatedUrls != null)
                    hashCode = hashCode * 59 + this.RelatedUrls.GetHashCode();
                if (this.Multimedia != null)
                    hashCode = hashCode * 59 + this.Multimedia.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
