using System.Windows.Input;
using NotesApp.WPF.Commands;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class AddNoteViewModel : BaseViewModel
    {
        public AddNoteViewModel(NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand addCommand = new AddNoteCommand(this, notesStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            NoteDetailsFormViewModel = new NoteDetailsFormViewModel(addCommand, cancelCommand);
        }

        public NoteDetailsFormViewModel NoteDetailsFormViewModel { get; }
    }
}