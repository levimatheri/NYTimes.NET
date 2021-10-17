using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class EmailedArticle : Article, IEquatable<EmailedArticle>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailedArticle" /> class.
        /// </summary>
        /// <param name="url">Article&#39;s URL..</param>
        /// <param name="adxKeywords">Semicolon separated list of keywords..</param>
        /// <param name="subsection">Article&#39;s subsection (e.g. Politics). Can be empty string..</param>
        /// <param name="column">Deprecated. Set to null..</param>
        /// <param name="etaId">Deprecated. Set to 0..</param>
        /// <param name="section">Article&#39;s section (e.g. Sports)..</param>
        /// <param name="id">Asset ID number (e.g. 100000007772696)..</param>
        /// <param name="assetId">Asset ID number (e.g. 100000007772696)..</param>
        /// <param name="nytdsection">Article&#39;s section (e.g. sports)..</param>
        /// <param name="byline">Article&#39;s byline (e.g. By Thomas L. Friedman)..</param>
        /// <param name="type">Asset type (e.g. Article, Interactive, ...)..</param>
        /// <param name="title">Article&#39;s headline (e.g. When the Cellos Play, the Cows Come Home)..</param>
        /// <param name="_abstract">Brief summary of the article..</param>
        /// <param name="publishedDate">When the article was published on the web (e.g. 2021-04-19)..</param>
        /// <param name="source">Publisher (e.g. New York Times)..</param>
        /// <param name="updated">When the article was last updated (e.g. 2021-05-12 06:32:03)..</param>
        /// <param name="desFacet">Array of description facets (e.g. Quarantine (Life and Culture))..</param>
        /// <param name="orgFacet">Array of organization facets (e.g. Sullivan Street Bakery)..</param>
        /// <param name="perFacet">Array of person facets (e.g. Bittman, Mark)..</param>
        /// <param name="geoFacet">Array of geographic facets (e.g. Canada)..</param>
        /// <param name="media">Array of images..</param>
        /// <param name="uri">An article&#39;s globally unique identifier..</param>
        public EmailedArticle(string url = default, string adxKeywords = default, string subsection = default, string column = default, int etaId = default, string section = default, long id = default, long assetId = default, string nytdsection = default,
            string byline = default, string type = default, string title = default, string _abstract = default, string publishedDate = default, string source = default, string updated = default, List<string> desFacet = default, List<string> orgFacet = default, 
            List<string> perFacet = default, List<string> geoFacet = default, List<Media> media = default, string uri = default)
            : base(id: id.ToString(), pubDate: publishedDate, uri: uri, byline: new Byline(original: byline), source: source, webUrl: url)
        {
            this.AdxKeywords = adxKeywords;
            this.Subsection = subsection;
            this.Column = column;
            this.EtaId = etaId;
            this.Section = section;
            this.AssetId = assetId;
            this.Nytdsection = nytdsection;
            this.Type = type;
            this.Title = title;
            this.Abstract = _abstract;
            this.Updated = updated;
            this.DesFacet = desFacet;
            this.OrgFacet = orgFacet;
            this.PerFacet = perFacet;
            this.GeoFacet = geoFacet;
            this.Media = media;
        }

        /// <summary>
        /// Semicolon separated list of keywords.
        /// </summary>
        /// <value>Semicolon separated list of keywords.</value>
        [DataMember(Name = "adx_keywords", EmitDefaultValue = false)]
        public string AdxKeywords { get; set; }

        /// <summary>
        /// Article&#39;s subsection (e.g. Politics). Can be empty string.
        /// </summary>
        /// <value>Article&#39;s subsection (e.g. Politics). Can be empty string.</value>
        [DataMember(Name = "subsection", EmitDefaultValue = false)]
        public string Subsection { get; set; }

        /// <summary>
        /// Deprecated. Set to null.
        /// </summary>
        /// <value>Deprecated. Set to null.</value>
        [DataMember(Name = "column", EmitDefaultValue = false)]
        public string Column { get; set; }

        /// <summary>
        /// Deprecated. Set to 0.
        /// </summary>
        /// <value>Deprecated. Set to 0.</value>
        [DataMember(Name = "eta_id", EmitDefaultValue = false)]
        public int EtaId { get; set; }

        /// <summary>
        /// Article&#39;s section (e.g. Sports).
        /// </summary>
        /// <value>Article&#39;s section (e.g. Sports).</value>
        [DataMember(Name = "section", EmitDefaultValue = false)]
        public string Section { get; set; }


        /// <summary>
        /// Asset ID number (e.g. 100000007772696).
        /// </summary>
        /// <value>Asset ID number (e.g. 100000007772696).</value>
        [DataMember(Name = "asset_id", EmitDefaultValue = false)]
        public long AssetId { get; set; }

        /// <summary>
        /// Article&#39;s section (e.g. sports).
        /// </summary>
        /// <value>Article&#39;s section (e.g. sports).</value>
        [DataMember(Name = "nytdsection", EmitDefaultValue = false)]
        public string Nytdsection { get; set; }


        /// <summary>
        /// Asset type (e.g. Article, Interactive, ...).
        /// </summary>
        /// <value>Asset type (e.g. Article, Interactive, ...).</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Article&#39;s headline (e.g. When the Cellos Play, the Cows Come Home).
        /// </summary>
        /// <value>Article&#39;s headline (e.g. When the Cellos Play, the Cows Come Home).</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Brief summary of the article.
        /// </summary>
        /// <value>Brief summary of the article.</value>
        [DataMember(Name = "abstract", EmitDefaultValue = false)]
        public string Abstract { get; set; }

        /// <summary>
        /// When the article was published on the web (e.g. 2021-04-19).
        /// </summary>
        /// <value>When the article was published on the web (e.g. 2021-04-19).</value>
        [DataMember(Name = "published_date", EmitDefaultValue = false)]
        public string PublishedDate { get; set; }

        /// <summary>
        /// When the article was last updated (e.g. 2021-05-12 06:32:03).
        /// </summary>
        /// <value>When the article was last updated (e.g. 2021-05-12 06:32:03).</value>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public string Updated { get; set; }

        /// <summary>
        /// Array of description facets (e.g. Quarantine (Life and Culture)).
        /// </summary>
        /// <value>Array of description facets (e.g. Quarantine (Life and Culture)).</value>
        [DataMember(Name = "des_facet", EmitDefaultValue = false)]
        public List<string> DesFacet { get; set; }

        /// <summary>
        /// Array of organization facets (e.g. Sullivan Street Bakery).
        /// </summary>
        /// <value>Array of organization facets (e.g. Sullivan Street Bakery).</value>
        [DataMember(Name = "org_facet", EmitDefaultValue = false)]
        public List<string> OrgFacet { get; set; }

        /// <summary>
        /// Array of person facets (e.g. Bittman, Mark).
        /// </summary>
        /// <value>Array of person facets (e.g. Bittman, Mark).</value>
        [DataMember(Name = "per_facet", EmitDefaultValue = false)]
        public List<string> PerFacet { get; set; }

        /// <summary>
        /// Array of geographic facets (e.g. Canada).
        /// </summary>
        /// <value>Array of geographic facets (e.g. Canada).</value>
        [DataMember(Name = "geo_facet", EmitDefaultValue = false)]
        public List<string> GeoFacet { get; set; }

        /// <summary>
        /// Array of images.
        /// </summary>
        /// <value>Array of images.</value>
        [DataMember(Name = "media", EmitDefaultValue = false)]
        public List<Media> Media { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmailedArticle {\n");
            sb.Append("  Url: ").Append(WebUrl).Append('\n');
            sb.Append("  AdxKeywords: ").Append(AdxKeywords).Append('\n');
            sb.Append("  Subsection: ").Append(Subsection).Append('\n');
            sb.Append("  Column: ").Append(Column).Append('\n');
            sb.Append("  EtaId: ").Append(EtaId).Append('\n');
            sb.Append("  Section: ").Append(Section).Append('\n');
            sb.Append("  Id: ").Append(Id).Append('\n');
            sb.Append("  AssetId: ").Append(AssetId).Append('\n');
            sb.Append("  Nytdsection: ").Append(Nytdsection).Append('\n');
            sb.Append("  Byline: ").Append(Byline).Append('\n');
            sb.Append("  Type: ").Append(Type).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  Abstract: ").Append(Abstract).Append('\n');
            sb.Append("  PublishedDate: ").Append(PublishedDate).Append('\n');
            sb.Append("  Source: ").Append(Source).Append('\n');
            sb.Append("  Updated: ").Append(Updated).Append('\n');
            sb.Append("  DesFacet: ").Append(DesFacet).Append('\n');
            sb.Append("  OrgFacet: ").Append(OrgFacet).Append('\n');
            sb.Append("  PerFacet: ").Append(PerFacet).Append('\n');
            sb.Append("  GeoFacet: ").Append(GeoFacet).Append('\n');
            sb.Append("  Media: ").Append(Media).Append('\n');
            sb.Append("  Uri: ").Append(Uri).Append('\n');
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
            return this.Equals(input as EmailedArticle);
        }

        /// <summary>
        /// Returns true if EmailedArticle instances are equal
        /// </summary>
        /// <param name="input">Instance of EmailedArticle to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmailedArticle input)
        {
            if (input == null)
                return false;

            return
                (
                    this.WebUrl == input.WebUrl ||
                    (this.WebUrl != null &&
                    this.WebUrl.Equals(input.WebUrl))
                ) &&
                (
                    this.AdxKeywords == input.AdxKeywords ||
                    (this.AdxKeywords != null &&
                    this.AdxKeywords.Equals(input.AdxKeywords))
                ) &&
                (
                    this.Subsection == input.Subsection ||
                    (this.Subsection != null &&
                    this.Subsection.Equals(input.Subsection))
                ) &&
                (
                    this.Column == input.Column ||
                    (this.Column != null &&
                    this.Column.Equals(input.Column))
                ) &&
                (
                    this.EtaId == input.EtaId ||
                    this.EtaId.Equals(input.EtaId)
                ) &&
                (
                    this.Section == input.Section ||
                    (this.Section != null &&
                    this.Section.Equals(input.Section))
                ) &&
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) &&
                (
                    this.AssetId == input.AssetId ||
                    this.AssetId.Equals(input.AssetId)
                ) &&
                (
                    this.Nytdsection == input.Nytdsection ||
                    (this.Nytdsection != null &&
                    this.Nytdsection.Equals(input.Nytdsection))
                ) &&
                (
                    this.Byline == input.Byline ||
                    (this.Byline != null &&
                    this.Byline.Equals(input.Byline))
                ) &&
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
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
                    this.PublishedDate == input.PublishedDate ||
                    (this.PublishedDate != null &&
                    this.PublishedDate.Equals(input.PublishedDate))
                ) &&
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) &&
                (
                    this.Updated == input.Updated ||
                    (this.Updated != null &&
                    this.Updated.Equals(input.Updated))
                ) &&
                (
                    this.DesFacet == input.DesFacet ||
                    this.DesFacet != null &&
                    input.DesFacet != null &&
                    this.DesFacet.SequenceEqual(input.DesFacet)
                ) &&
                (
                    this.OrgFacet == input.OrgFacet ||
                    this.OrgFacet != null &&
                    input.OrgFacet != null &&
                    this.OrgFacet.SequenceEqual(input.OrgFacet)
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
                    this.Media == input.Media ||
                    this.Media != null &&
                    input.Media != null &&
                    this.Media.SequenceEqual(input.Media)
                ) &&
                (
                    this.Uri == input.Uri ||
                    (this.Uri != null &&
                    this.Uri.Equals(input.Uri))
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
                if (this.WebUrl != null)
                    hashCode = hashCode * 59 + this.WebUrl.GetHashCode();
                if (this.AdxKeywords != null)
                    hashCode = hashCode * 59 + this.AdxKeywords.GetHashCode();
                if (this.Subsection != null)
                    hashCode = hashCode * 59 + this.Subsection.GetHashCode();
                if (this.Column != null)
                    hashCode = hashCode * 59 + this.Column.GetHashCode();
                hashCode = hashCode * 59 + this.EtaId.GetHashCode();
                if (this.Section != null)
                    hashCode = hashCode * 59 + this.Section.GetHashCode();
                hashCode = hashCode * 59 + this.Id.GetHashCode();
                hashCode = hashCode * 59 + this.AssetId.GetHashCode();
                if (this.Nytdsection != null)
                    hashCode = hashCode * 59 + this.Nytdsection.GetHashCode();
                if (this.Byline != null)
                    hashCode = hashCode * 59 + this.Byline.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Abstract != null)
                    hashCode = hashCode * 59 + this.Abstract.GetHashCode();
                if (this.PublishedDate != null)
                    hashCode = hashCode * 59 + this.PublishedDate.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.Updated != null)
                    hashCode = hashCode * 59 + this.Updated.GetHashCode();
                if (this.DesFacet != null)
                    hashCode = hashCode * 59 + this.DesFacet.GetHashCode();
                if (this.OrgFacet != null)
                    hashCode = hashCode * 59 + this.OrgFacet.GetHashCode();
                if (this.PerFacet != null)
                    hashCode = hashCode * 59 + this.PerFacet.GetHashCode();
                if (this.GeoFacet != null)
                    hashCode = hashCode * 59 + this.GeoFacet.GetHashCode();
                if (this.Media != null)
                    hashCode = hashCode * 59 + this.Media.GetHashCode();
                if (this.Uri != null)
                    hashCode = hashCode * 59 + this.Uri.GetHashCode();
                return hashCode;
            }
        }
    }
}
