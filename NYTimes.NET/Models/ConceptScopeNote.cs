using System.Runtime.Serialization;

namespace NYTimes.NET.Models
{
    [DataContract(Name = "scope_notes")]
    public class ConceptScopeNote : ModelBase
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
    }
}