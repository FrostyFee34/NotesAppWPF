using System;

namespace NotesApp.Domain.Models
{
    public class Note
    {
        public Note(Guid id, string header, string content, bool isDone, DateTime? deadline)
        {
            Id = id;
            Header = header;
            Content = content;
            IsDone = isDone;
            Deadline = deadline;
        }

        public Guid Id { get; }
        public string Header { get; }
        public string Content { get; }
        public bool IsDone { get; }
        public DateTime? Deadline { get; }
    }
}