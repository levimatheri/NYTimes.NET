using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// BestSellerListName
    /// </summary>
    [DataContract(Name = "results")]
    public class BestSellerListName : ModelBase
    {
        /// <summary>
        /// Defines Updated
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpdatedEnum
        {
            /// <summary>
            /// Enum WEEKLY for value: WEEKLY
            /// </summary>
            [EnumMember(Value = "WEEKLY")]
            WEEKLY = 1,

            /// <summary>
            /// Enum MONTHLY for value: MONTHLY
            /// </summary>
            [EnumMember(Value = "MONTHLY")]
            MONTHLY = 2
        }


        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [DataMember(Name = "updated", EmitDefaultValue = false)]
        public UpdatedEnum? Updated { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BestSellerListName" /> class.
        /// </summary>
        /// <param name="listName">listName.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="listNameEncoded">listNameEncoded.</param>
        /// <param name="oldestPublishedDate">oldestPublishedDate.</param>
        /// <param name="newestPublishedDate">newestPublishedDate.</param>
        /// <param name="updated">updated.</param>
        public BestSellerListName(string listName = default, string displayName = default, string listNameEncoded = default,
            string oldestPublishedDate = default, string newestPublishedDate = default, UpdatedEnum? updated = default)
        {
            this.ListName = listName;
            this.DisplayName = displayName;
            this.ListNameEncoded = listNameEncoded;
            this.OldestPublishedDate = oldestPublishedDate;
            this.NewestPublishedDate = newestPublishedDate;
            this.Updated = updated;
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
        /// Gets or Sets ListNameEncoded
        /// </summary>
        [DataMember(Name = "list_name_encoded", EmitDefaultValue = false)]
        public string ListNameEncoded { get; }

        /// <summary>
        /// Gets or Sets OldestPublishedDate
        /// </summary>
        [DataMember(Name = "oldest_published_date", EmitDefaultValue = false)]
        public string OldestPublishedDate { get; }

        /// <summary>
        /// Gets or Sets NewestPublishedDate
        /// </summary>
        [DataMember(Name = "newest_published_date", EmitDefaultValue = false)]
        public string NewestPublishedDate { get; }
    }
}