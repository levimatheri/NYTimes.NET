using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class MovieReview
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Review" /> class.
        /// </summary>
        /// <param name="displayTitle">Movie title..</param>
        /// <param name="mpaaRating">Movie MPAA rating (e.g. PG-13)..</param>
        /// <param name="criticsPick">Set to 1 if a critics&#39; pick and 0 if not..</param>
        /// <param name="byline">Author of the review (e.g. Manohla Dargis)..</param>
        /// <param name="headline">Headline of the review..</param>
        /// <param name="summaryShort">Short summary about the review..</param>
        /// <param name="publicationDate">Review publication date..</param>
        /// <param name="openingDate">Movie U.S. opening date..</param>
        /// <param name="dateUpdated">Last modified date of the review..</param>
        /// <param name="link">link.</param>
        /// <param name="multimedia">multimedia.</param>
        public MovieReview(string displayTitle = default, string mpaaRating = default, int criticsPick = default, string byline = default, string headline = default, 
            string summaryShort = default, string publicationDate = default, string openingDate = default, string dateUpdated = default, Link link = default, Multimedia multimedia = default)
        {
            this.DisplayTitle = displayTitle;
            this.MpaaRating = mpaaRating;
            this.CriticsPick = criticsPick;
            this.Byline = byline;
            this.Headline = headline;
            this.SummaryShort = summaryShort;
            this.PublicationDate = publicationDate;
            this.OpeningDate = openingDate;
            this.DateUpdated = dateUpdated;
            this.Link = link;
            this.Multimedia = multimedia;
        }

        /// <summary>
        /// Movie title.
        /// </summary>
        /// <value>Movie title.</value>
        [DataMember(Name = "display_title", EmitDefaultValue = false)]
        public string DisplayTitle { get; set; }

        /// <summary>
        /// Movie MPAA rating (e.g. PG-13).
        /// </summary>
        /// <value>Movie MPAA rating (e.g. PG-13).</value>
        [DataMember(Name = "mpaa_rating", EmitDefaultValue = false)]
        public string MpaaRating { get; set; }

        /// <summary>
        /// Set to 1 if a critics&#39; pick and 0 if not.
        /// </summary>
        /// <value>Set to 1 if a critics&#39; pick and 0 if not.</value>
        [DataMember(Name = "critics_pick", EmitDefaultValue = false)]
        public int CriticsPick { get; set; }

        /// <summary>
        /// Author of the review (e.g. Manohla Dargis).
        /// </summary>
        /// <value>Author of the review (e.g. Manohla Dargis).</value>
        [DataMember(Name = "byline", EmitDefaultValue = false)]
        public string Byline { get; set; }

        /// <summary>
        /// Headline of the review.
        /// </summary>
        /// <value>Headline of the review.</value>
        [DataMember(Name = "headline", EmitDefaultValue = false)]
        public string Headline { get; set; }

        /// <summary>
        /// Short summary about the review.
        /// </summary>
        /// <value>Short summary about the review.</value>
        [DataMember(Name = "summary_short", EmitDefaultValue = false)]
        public string SummaryShort { get; set; }

        /// <summary>
        /// Review publication date.
        /// </summary>
        /// <value>Review publication date.</value>
        [DataMember(Name = "publication_date", EmitDefaultValue = false)]
        public string PublicationDate { get; set; }

        /// <summary>
        /// Movie U.S. opening date.
        /// </summary>
        /// <value>Movie U.S. opening date.</value>
        [DataMember(Name = "opening_date", EmitDefaultValue = false)]
        public string OpeningDate { get; set; }

        /// <summary>
        /// Last modified date of the review.
        /// </summary>
        /// <value>Last modified date of the review.</value>
        [DataMember(Name = "date_updated", EmitDefaultValue = false)]
        public string DateUpdated { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public Link Link { get; set; }

        /// <summary>
        /// Gets or Sets Multimedia
        /// </summary>
        [DataMember(Name = "multimedia", EmitDefaultValue = false)]
        public Multimedia Multimedia { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Review {\n");
            sb.Append("  DisplayTitle: ").Append(DisplayTitle).Append("\n");
            sb.Append("  MpaaRating: ").Append(MpaaRating).Append("\n");
            sb.Append("  CriticsPick: ").Append(CriticsPick).Append("\n");
            sb.Append("  Byline: ").Append(Byline).Append("\n");
            sb.Append("  Headline: ").Append(Headline).Append("\n");
            sb.Append("  SummaryShort: ").Append(SummaryShort).Append("\n");
            sb.Append("  PublicationDate: ").Append(PublicationDate).Append("\n");
            sb.Append("  OpeningDate: ").Append(OpeningDate).Append("\n");
            sb.Append("  DateUpdated: ").Append(DateUpdated).Append("\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  Multimedia: ").Append(Multimedia).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as MovieReview);
        }

        /// <summary>
        /// Returns true if Review instances are equal
        /// </summary>
        /// <param name="input">Instance of Review to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MovieReview input)
        {
            if (input == null)
                return false;

            return
                (
                    this.DisplayTitle == input.DisplayTitle ||
                    (this.DisplayTitle != null &&
                    this.DisplayTitle.Equals(input.DisplayTitle))
                ) &&
                (
                    this.MpaaRating == input.MpaaRating ||
                    (this.MpaaRating != null &&
                    this.MpaaRating.Equals(input.MpaaRating))
                ) &&
                (
                    this.CriticsPick == input.CriticsPick ||
                    this.CriticsPick.Equals(input.CriticsPick)
                ) &&
                (
                    this.Byline == input.Byline ||
                    (this.Byline != null &&
                    this.Byline.Equals(input.Byline))
                ) &&
                (
                    this.Headline == input.Headline ||
                    (this.Headline != null &&
                    this.Headline.Equals(input.Headline))
                ) &&
                (
                    this.SummaryShort == input.SummaryShort ||
                    (this.SummaryShort != null &&
                    this.SummaryShort.Equals(input.SummaryShort))
                ) &&
                (
                    this.PublicationDate == input.PublicationDate ||
                    (this.PublicationDate != null &&
                    this.PublicationDate.Equals(input.PublicationDate))
                ) &&
                (
                    this.OpeningDate == input.OpeningDate ||
                    (this.OpeningDate != null &&
                    this.OpeningDate.Equals(input.OpeningDate))
                ) &&
                (
                    this.DateUpdated == input.DateUpdated ||
                    (this.DateUpdated != null &&
                    this.DateUpdated.Equals(input.DateUpdated))
                ) &&
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
                ) &&
                (
                    this.Multimedia == input.Multimedia ||
                    (this.Multimedia != null &&
                    this.Multimedia.Equals(input.Multimedia))
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
                int hashCode = 41;
                if (this.DisplayTitle != null)
                    hashCode = hashCode * 59 + this.DisplayTitle.GetHashCode();
                if (this.MpaaRating != null)
                    hashCode = hashCode * 59 + this.MpaaRating.GetHashCode();
                hashCode = hashCode * 59 + this.CriticsPick.GetHashCode();
                if (this.Byline != null)
                    hashCode = hashCode * 59 + this.Byline.GetHashCode();
                if (this.Headline != null)
                    hashCode = hashCode * 59 + this.Headline.GetHashCode();
                if (this.SummaryShort != null)
                    hashCode = hashCode * 59 + this.SummaryShort.GetHashCode();
                if (this.PublicationDate != null)
                    hashCode = hashCode * 59 + this.PublicationDate.GetHashCode();
                if (this.OpeningDate != null)
                    hashCode = hashCode * 59 + this.OpeningDate.GetHashCode();
                if (this.DateUpdated != null)
                    hashCode = hashCode * 59 + this.DateUpdated.GetHashCode();
                if (this.Link != null)
                    hashCode = hashCode * 59 + this.Link.GetHashCode();
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
