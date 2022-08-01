using System.Windows.Input;
using NotesApp.WPF.Commands;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class NotesViewModel : BaseViewModel
    {
        public NotesViewModel(NotesStore notesStore, SelectedNoteStore selectedNoteStore,
            ModalNavigationStore modalNavigationStore)
        {
            NoteDetailsViewModel = new NoteDetailsViewModel(selectedNoteStore);
            NotesListingViewModel = new NotesListingViewModel(notesStore, selectedNoteStore, modalNavigationStore);

            AddNoteCommand = new OpenAddNoteCommand(notesStore,modalNavigationStore);
        }

        public NoteDetailsViewModel NoteDetailsViewModel { get; }
        public NotesListingViewModel NotesListingViewModel { get; }
        public ICommand AddNoteCommand { get; }
    }
}