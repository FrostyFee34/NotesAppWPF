using System.Windows.Input;
using NotesApp.WPF.Commands;
using NotesApp.Domain.Models;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class NotesListingItemViewModel : BaseViewModel
    {
        
        public NotesListingItemViewModel(Note note, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            Note = note;
            EditCommand = new OpenEditNoteCommand(this, notesStore, modalNavigationStore);
            DeleteCommand = new DeleteNoteCommand(this, notesStore);
        }


        public Note Note { get; private set; }

        public string Header => Note.Header;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public void Update(Note note)
        {
            Note = note;
            OnPropertyChanged(nameof(Header));
        }
    }
}