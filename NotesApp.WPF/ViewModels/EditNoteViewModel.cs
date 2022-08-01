using System;
using System.Windows.Input;
using NotesApp.WPF.Commands;
using NotesApp.Domain.Models;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class EditNoteViewModel : BaseViewModel
    {
        public Guid NoteId { get; }

        public EditNoteViewModel(Note note, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            NoteId = note.Id;
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ICommand editCommand = new EditNoteCommand(this, notesStore, modalNavigationStore);
            NoteDetailsFormViewModel = new NoteDetailsFormViewModel(editCommand, cancelCommand)
            {
                Header = note.Header,
                Content = note.Content,
                Deadline = note.Deadline,
                IsDone = note.IsDone
            };
        }

        public NoteDetailsFormViewModel NoteDetailsFormViewModel { get; }
    }
}