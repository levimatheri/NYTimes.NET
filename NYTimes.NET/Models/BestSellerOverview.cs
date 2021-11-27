using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BestSellerOverview : ModelBase
    {
        public BestSellerOverview(){}
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerOverview" /> class.
        /// </summary>
        /// <param name="bestsellersDate">bestsellersDate.</param>
        /// <param name="publishedDate">publishedDate.</param>
        /// <param name="lists">lists.</param>
        public BestSellerOverview(string bestsellersDate = default, string publishedDate = default, List<BestSellerListName> lists = default)
        {
            this.BestsellersDate = bestsellersDate;
            this.PublishedDate = publishedDate;
            this.Lists = lists;
        }

        /// <summary>
        /// Gets or Sets BestsellersDate
        /// </summary>
        [DataMember(Name = "bestsellers_date", EmitDefaultValue = false)]
        public string BestsellersDate { get; }

        /// <summary>
        /// Gets or Sets PublishedDate
        /// </summary>
        [DataMember(Name = "published_date", EmitDefaultValue = false)]
        public string PublishedDate { get; }

        /// <summary>
        /// Gets or Sets Lists
        /// </summary>
        [DataMember(Name = "lists", EmitDefaultValue = false)]
        public List<BestSellerListName> Lists { get; }
    }
}