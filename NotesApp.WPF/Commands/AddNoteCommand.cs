using System;
using System.Threading.Tasks;
using NotesApp.Domain.Models;
using NotesApp.WPF.Stores;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF.Commands
{
    public class AddNoteCommand : AsyncBaseCommand
    {
        private readonly AddNoteViewModel _addNoteViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NotesStore _notesStore;

        public AddNoteCommand(AddNoteViewModel addNoteViewModel, NotesStore notesStore,
            ModalNavigationStore modalNavigationStore)
        {
            _addNoteViewModel = addNoteViewModel;
            _notesStore = notesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var formViewModel = _addNoteViewModel.NoteDetailsFormViewModel;
            var note = new Note(Guid.NewGuid(), formViewModel.Header, 
                formViewModel.Content, formViewModel.IsDone,
                formViewModel.Deadline);

            try
            {
                await _notesStore.CreateAsync(note);
                // add note to db
                _modalNavigationStore.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}