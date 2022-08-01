using System;
using System.Threading.Tasks;
using NotesApp.Domain.Models;
using NotesApp.WPF.Stores;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF.Commands
{
    public class EditNoteCommand : AsyncBaseCommand
    {
        private readonly EditNoteViewModel _editNoteViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NotesStore _notesStore;

        public EditNoteCommand(EditNoteViewModel editNoteViewModel, NotesStore notesStore,
            ModalNavigationStore modalNavigationStore)
        {
            _editNoteViewModel = editNoteViewModel;
            _notesStore = notesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var formViewModel = _editNoteViewModel.NoteDetailsFormViewModel;
            var note = new Note(_editNoteViewModel.NoteId, formViewModel.Header,
                formViewModel.Content, formViewModel.IsDone,
                formViewModel.Deadline);

            try
            {
                await _notesStore.UpdateAsync(note);
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