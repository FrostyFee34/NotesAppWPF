using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotesApp.Domain.Commands;
using NotesApp.Domain.Models;
using NotesApp.Domain.Queries;

namespace NotesApp.WPF.Stores
{
    public class NotesStore
    {
        private readonly ICreateNoteCommand _createNoteCommand;
        private readonly IDeleteNoteCommand _deleteNoteCommand;
        private readonly IGetAllNotesQuery _getAllNotesQuery;
        private readonly IUpdateNoteCommand _updateNoteCommand;
        private readonly List<Note> _notes;

        public NotesStore(IUpdateNoteCommand updateNoteCommand, ICreateNoteCommand createNoteCommand,
            IDeleteNoteCommand deleteNoteCommand, IGetAllNotesQuery getAllNotesQuery)
        {
            _updateNoteCommand = updateNoteCommand;
            _createNoteCommand = createNoteCommand;
            _deleteNoteCommand = deleteNoteCommand;
            _getAllNotesQuery = getAllNotesQuery;

            _notes = new List<Note>();
        }

        public IEnumerable<Note> Notes => _notes;

        public event Action NotesLoaded;
        public event Action<Note> NoteCreated;
        public event Action<Note> NoteUpdated;
        public event Action<Guid> NoteDeleted;

        public async Task CreateAsync(Note note)
        {
            await _createNoteCommand.Execute(note);

            _notes.Add(note); 
            NoteCreated?.Invoke(note);
        }

        public async Task UpdateAsync(Note note)
        {
            await _updateNoteCommand.Execute(note);

            var index = _notes.FindIndex(n => n.Id == note.Id);
            if (index > -1)
            {
                _notes[index] = note;
            }
            else
            {
                _notes.Add(note);
            }

            NoteUpdated?.Invoke(note);
        }

        public async Task LoadAsync()
        {
            var notes = await _getAllNotesQuery.Execute();

            _notes.Clear();
            _notes.AddRange(notes);

            NotesLoaded?.Invoke();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _deleteNoteCommand.Execute(id);

            _notes.RemoveAll(n => n.Id == id);

            NoteDeleted?.Invoke(id);
        }
    }
}