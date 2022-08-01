using System;
using System.Threading.Tasks;
using NotesApp.WPF.Stores;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF.Commands
{
    public class DeleteNoteCommand : AsyncBaseCommand
    {
        private readonly NotesListingItemViewModel _notesListingItemViewModel;
        private readonly NotesStore _notesStore;

        public DeleteNoteCommand(NotesListingItemViewModel notesListingItemViewModel, NotesStore notesStore)
        {
            _notesListingItemViewModel = notesListingItemViewModel;
            _notesStore = notesStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var note = _notesListingItemViewModel.Note;

            try
            {
                await _notesStore.DeleteAsync(note.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}