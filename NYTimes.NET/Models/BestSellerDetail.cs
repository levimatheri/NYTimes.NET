using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "results")]
    public class BestSellerDetail : BestSellerOverview
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerDetail" /> class.
        /// </summary>
        /// <param name="listName">listName.</param>
        /// <param name="bestsellersDate">bestsellersDate.</param>
        /// <param name="publishedDate">publishedDate.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="normalListEndsAt">normalListEndsAt.</param>
        /// <param name="updated">updated.</param>
        /// <param name="books">books.</param>
        /// <param name="corrections">corrections.</param>
        public BestSellerDetail(string listName = default, string bestsellersDate = default, string publishedDate = default, 
            string displayName = default, int normalListEndsAt = default, string updated = default, List<BestSellerBook> books = default, List<object> corrections = default) 
            : base(bestsellersDate, publishedDate)
        {
            this.ListName = listName;
            this.DisplayName = displayName;
            this.NormalListEndsAt = normalListEndsAt;
            this.Updated = updated;
            this.Books = books;
            this.Corrections = corrections;
        }

        /// <summary>
        /// Gets or Sets ListName
        /// </summary>
        [DataMember(Name = "list_name", EmitDefaultValue = false)]
        public string ListName { get; }
        

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "display_name", EmitDefaultValue = false)]
        public string DisplayName { get; }

        /// <summary>
        /// Gets or Sets NormalListEndsAt
        /// </summary>
        [DataMember(Name = "normal_list_ends_at", EmitDefaultValue = false)]
        public int NormalListEndsAt { get; }

        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public string Updated { get; }

        /// <summary>
        /// Gets or Sets Books
        /// </summary>
        [DataMember(Name = "books", EmitDefaultValue = false)]
        public List<BestSellerBook> Books { get; }

        /// <summary>
        /// Gets or Sets Corrections
        /// </summary>
        [DataMember(Name = "corrections", EmitDefaultValue = false)]
        public List<object> Corrections { get; }
    }
}