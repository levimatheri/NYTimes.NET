using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Person
    /// </summary>
    [DataContract(Name = "person")]
    public class Person : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
        /// <param name="firstname">firstname.</param>
        /// <param name="middlename">middlename.</param>
        /// <param name="lastname">lastname.</param>
        /// <param name="qualifier">qualifier.</param>
        /// <param name="title">title.</param>
        /// <param name="role">role.</param>
        /// <param name="organization">organization.</param>
        /// <param name="rank">rank.</param>
        public Person(string firstname = default(string), string middlename = default(string), string lastname = default(string), string qualifier = default(string), string title = default(string), string role = default(string), string organization = default(string), int rank = default(int))
        {
            this.Firstname = firstname;
            this.Middlename = middlename;
            this.Lastname = lastname;
            this.Qualifier = qualifier;
            this.Title = title;
            this.Role = role;
            this.Organization = organization;
            this.Rank = rank;
        }

        /// <summary>
        /// Gets or Sets Firstname
        /// </summary>
        [DataMember(Name = "firstname", EmitDefaultValue = false)]
        public string Firstname { get; }

        /// <summary>
        /// Gets or Sets Middlename
        /// </summary>
        [DataMember(Name = "middlename", EmitDefaultValue = false)]
        public string Middlename { get; }

        /// <summary>
        /// Gets or Sets Lastname
        /// </summary>
        [DataMember(Name = "lastname", EmitDefaultValue = false)]
        public string Lastname { get; }

        /// <summary>
        /// Gets or Sets Qualifier
        /// </summary>
        [DataMember(Name = "qualifier", EmitDefaultValue = false)]
        public string Qualifier { get; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public string Role { get; }

        /// <summary>
        /// Gets or Sets Organization
        /// </summary>
        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public string Organization { get; }

        /// <summary>
        /// Gets or Sets Rank
        /// </summary>
        [DataMember(Name = "rank", EmitDefaultValue = false)]
        public int Rank { get; }
    }
}
