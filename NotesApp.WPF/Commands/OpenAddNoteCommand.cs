using NotesApp.WPF.Stores;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF.Commands
{
    public class OpenAddNoteCommand : BaseCommand
    {
        private readonly NotesStore _notesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddNoteCommand(NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            _notesStore = notesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddNoteViewModel addNoteViewModel = new AddNoteViewModel(_notesStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addNoteViewModel;
        }
    }
}