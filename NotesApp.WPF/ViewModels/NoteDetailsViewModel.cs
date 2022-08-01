using System;
using NotesApp.Domain.Models;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class NoteDetailsViewModel : BaseViewModel
    {
        private readonly SelectedNoteStore _selectedNoteStore;

        public NoteDetailsViewModel(SelectedNoteStore selectedNoteStore)
        {
            _selectedNoteStore = selectedNoteStore;
            _selectedNoteStore.SelectedNoteChanged += SelectedNoteStoreOnSelectedNoteChanged;
        }

        private Note SelectedNote => _selectedNoteStore.SelectedNote;
        public bool HasNoteSelected => SelectedNote != null;
        public DateTime Deadline => SelectedNote?.Deadline ?? DateTime.Now;
        public string Header => SelectedNote?.Header ?? "Header";
        public string Content => SelectedNote?.Content ?? "Content";
        public string IsDone => SelectedNote?.IsDone ?? false ? "Yes" : "No";

        private void SelectedNoteStoreOnSelectedNoteChanged()
        {
            OnPropertyChanged(nameof(HasNoteSelected));
            OnPropertyChanged(nameof(Deadline));
            OnPropertyChanged(nameof(Header));
            OnPropertyChanged(nameof(Content));
            OnPropertyChanged(nameof(IsDone));
        }

        protected override void Dispose()
        {
            _selectedNoteStore.SelectedNoteChanged -= SelectedNoteStoreOnSelectedNoteChanged;
            base.Dispose();
        }
    }
}