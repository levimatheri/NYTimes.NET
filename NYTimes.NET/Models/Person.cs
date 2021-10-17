using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NYTimes.NET.Models
{
    /// <summary>
    /// Person
    /// </summary>
    [DataContract(Name = "person")]
    public class Person : IEquatable<Person>, IValidatableObject
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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Person {\n");
            sb.Append("  Firstname: ").Append(Firstname).Append('\n');
            sb.Append("  Middlename: ").Append(Middlename).Append('\n');
            sb.Append("  Lastname: ").Append(Lastname).Append('\n');
            sb.Append("  Qualifier: ").Append(Qualifier).Append('\n');
            sb.Append("  Title: ").Append(Title).Append('\n');
            sb.Append("  Role: ").Append(Role).Append('\n');
            sb.Append("  Organization: ").Append(Organization).Append('\n');
            sb.Append("  Rank: ").Append(Rank).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Person);
        }

        /// <summary>
        /// Returns true if Person instances are equal
        /// </summary>
        /// <param name="input">Instance of Person to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Person input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Firstname == input.Firstname ||
                    (this.Firstname != null &&
                    this.Firstname.Equals(input.Firstname))
                ) && 
                (
                    this.Middlename == input.Middlename ||
                    (this.Middlename != null &&
                    this.Middlename.Equals(input.Middlename))
                ) && 
                (
                    this.Lastname == input.Lastname ||
                    (this.Lastname != null &&
                    this.Lastname.Equals(input.Lastname))
                ) && 
                (
                    this.Qualifier == input.Qualifier ||
                    (this.Qualifier != null &&
                    this.Qualifier.Equals(input.Qualifier))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Role == input.Role ||
                    (this.Role != null &&
                    this.Role.Equals(input.Role))
                ) && 
                (
                    this.Organization == input.Organization ||
                    (this.Organization != null &&
                    this.Organization.Equals(input.Organization))
                ) && 
                (
                    this.Rank == input.Rank ||
                    this.Rank.Equals(input.Rank)
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
                if (this.Firstname != null)
                    hashCode = hashCode * 59 + this.Firstname.GetHashCode();
                if (this.Middlename != null)
                    hashCode = hashCode * 59 + this.Middlename.GetHashCode();
                if (this.Lastname != null)
                    hashCode = hashCode * 59 + this.Lastname.GetHashCode();
                if (this.Qualifier != null)
                    hashCode = hashCode * 59 + this.Qualifier.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Role != null)
                    hashCode = hashCode * 59 + this.Role.GetHashCode();
                if (this.Organization != null)
                    hashCode = hashCode * 59 + this.Organization.GetHashCode();
                hashCode = hashCode * 59 + this.Rank.GetHashCode();
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
