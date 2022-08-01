using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using NotesApp.Domain.Models;
using NotesApp.WPF.Commands;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class NotesListingViewModel : BaseViewModel
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ObservableCollection<NotesListingItemViewModel> _notesListingItemViewModels;
        private readonly NotesStore _notesStore;
        private readonly SelectedNoteStore _selectedNoteStore;
        private NotesListingItemViewModel _selectedNotesListingItemViewModel;

        public NotesListingViewModel(NotesStore notesStore, SelectedNoteStore selectedNoteStore,
            ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            LoadNotesCommand = new LoadNotesCommand(notesStore);

            _notesStore = notesStore;
            _selectedNoteStore = selectedNoteStore;
            _notesListingItemViewModels = new ObservableCollection<NotesListingItemViewModel>();

            _notesStore.NotesLoaded += NotesStoreOnNotesLoaded;
            _notesStore.NoteCreated += NotesStoreOnNoteCreated;
            _notesStore.NoteUpdated += NotesStoreOnNoteUpdated;
            _notesStore.NoteDeleted += NotesStoreOnNoteDeleted;

            LoadNotesCommand.Execute(null);
        }

        private void NotesStoreOnNoteDeleted(Guid obj)
        {
            var note = _notesListingItemViewModels.FirstOrDefault(n => n.Note.Id == obj);

            if (note != null)
            {
                _notesListingItemViewModels.Remove(note);
            }
        }

        public NotesListingItemViewModel SelectedNotesListingItemViewModel
        {
            get => _selectedNotesListingItemViewModel;
            set
            {
                _selectedNotesListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedNotesListingItemViewModel));
                _selectedNoteStore.SelectedNote = SelectedNotesListingItemViewModel?.Note;
            }
        }

        public IEnumerable<NotesListingItemViewModel> NotesListingItemViewModels => _notesListingItemViewModels;

        public ICommand LoadNotesCommand { get; }

        private void NotesStoreOnNotesLoaded()
        {
            _notesListingItemViewModels.Clear();
            foreach (var note in _notesStore.Notes) AddNote(note);
        }

        private void NotesStoreOnNoteUpdated(Note obj)
        {
            var noteViewModel = _notesListingItemViewModels.FirstOrDefault(n => n.Note.Id == obj.Id);
            if (noteViewModel != null) noteViewModel.Update(obj);
        }

        private void NotesStoreOnNoteCreated(Note note)
        {
            AddNote(note);
        }

        protected override void Dispose()
        {
            _notesStore.NotesLoaded -= NotesStoreOnNotesLoaded;
            _notesStore.NoteUpdated -= NotesStoreOnNoteUpdated;
            _notesStore.NoteCreated -= NotesStoreOnNoteCreated;
            base.Dispose();
        }

        private void AddNote(Note note)
        {
            _notesListingItemViewModels.Add(new NotesListingItemViewModel(note, _notesStore, _modalNavigationStore));
        }
    }
}