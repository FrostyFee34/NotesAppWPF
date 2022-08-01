using NotesApp.Domain.Models;
using NotesApp.WPF.Stores;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF.Commands
{
    public class OpenEditNoteCommand : BaseCommand
    {
        private readonly NotesListingItemViewModel _notesListingItemViewModel;
        private readonly NotesStore _notesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditNoteCommand(NotesListingItemViewModel notesListingItemViewModel, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            _notesListingItemViewModel = notesListingItemViewModel;
            _notesStore = notesStore;
            _modalNavigationStore = modalNavigationStore;
        }


        public override void Execute(object parameter)
        {
            var note = _notesListingItemViewModel.Note;
            var editNoteViewModel = new EditNoteViewModel(note, _notesStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editNoteViewModel;
        }
    }
}