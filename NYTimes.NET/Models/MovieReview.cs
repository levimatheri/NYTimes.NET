using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class MovieReview : ModelBase
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
    }
}
