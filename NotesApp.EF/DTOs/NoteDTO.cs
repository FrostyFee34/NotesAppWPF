using System;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.EF.DTOs
{
    public class NoteDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public DateTime? Deadline { get; set; }
    }
}