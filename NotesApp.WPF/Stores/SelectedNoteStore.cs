using System;
using NotesApp.Domain.Models;

namespace NotesApp.WPF.Stores
{
    public class SelectedNoteStore
    {
        private readonly NotesStore _notesStore;
        private Note _selectedNote;

        public SelectedNoteStore(NotesStore notesStore)
        {
            _notesStore = notesStore;
            _notesStore.NoteUpdated += NotesStoreOnNoteUpdated;
            _notesStore.NoteDeleted += NotesStoreOnNoteDeleted;
        }

        public Note SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                SelectedNoteChanged?.Invoke();
            }
        }

        private void NotesStoreOnNoteDeleted(Guid obj)
        {
            if (obj == SelectedNote?.Id) SelectedNote = null;
        }

        private void NotesStoreOnNoteUpdated(Note obj)
        {
            if (obj.Id == SelectedNote?.Id) SelectedNote = obj;
        }

        public event Action SelectedNoteChanged;
    }
}