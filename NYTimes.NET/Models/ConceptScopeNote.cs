using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "scope_notes")]
    public class ConceptScopeNote : IEquatable<ConceptScopeNote>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptScopeNote" /> class.
        /// </summary>
        /// <param name="scopeNote">scopeNote.</param>
        /// <param name="scopeNoteName">scopeNoteName.</param>
        /// <param name="scopeNoteType">scopeNoteType.</param>
        public ConceptScopeNote(string scopeNote = default, string scopeNoteName = default, string scopeNoteType = default)
        {
            this.ScopeNote = scopeNote;
            this.ScopeNoteName = scopeNoteName;
            this.ScopeNoteType = scopeNoteType;
        }

        /// <summary>
        /// Gets or Sets ScopeNote
        /// </summary>
        [DataMember(Name = "scope_note", EmitDefaultValue = false)]
        public string ScopeNote { get; set; }

        /// <summary>
        /// Gets or Sets ScopeNoteName
        /// </summary>
        [DataMember(Name = "scope_note_name", EmitDefaultValue = false)]
        public string ScopeNoteName { get; set; }

        /// <summary>
        /// Gets or Sets ScopeNoteType
        /// </summary>
        [DataMember(Name = "scope_note_type", EmitDefaultValue = false)]
        public string ScopeNoteType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConceptScopeNote {\n");
            sb.Append("  ScopeNote: ").Append(ScopeNote).Append('\n');
            sb.Append("  ScopeNoteName: ").Append(ScopeNoteName).Append('\n');
            sb.Append("  ScopeNoteType: ").Append(ScopeNoteType).Append('\n');
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
            return this.Equals(input as ConceptScopeNote);
        }

        /// <summary>
        /// Returns true if ConceptScopeNote instances are equal
        /// </summary>
        /// <param name="input">Instance of ConceptScopeNote to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConceptScopeNote input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ScopeNote == input.ScopeNote ||
                    (this.ScopeNote != null &&
                    this.ScopeNote.Equals(input.ScopeNote))
                ) &&
                (
                    this.ScopeNoteName == input.ScopeNoteName ||
                    (this.ScopeNoteName != null &&
                    this.ScopeNoteName.Equals(input.ScopeNoteName))
                ) &&
                (
                    this.ScopeNoteType == input.ScopeNoteType ||
                    (this.ScopeNoteType != null &&
                    this.ScopeNoteType.Equals(input.ScopeNoteType))
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
                if (this.ScopeNote != null)
                    hashCode = hashCode * 59 + this.ScopeNote.GetHashCode();
                if (this.ScopeNoteName != null)
                    hashCode = hashCode * 59 + this.ScopeNoteName.GetHashCode();
                if (this.ScopeNoteType != null)
                    hashCode = hashCode * 59 + this.ScopeNoteType.GetHashCode();
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