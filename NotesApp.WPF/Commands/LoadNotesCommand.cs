using System;
using System.Threading.Tasks;
using NotesApp.WPF.Stores;

namespace NotesApp.WPF.Commands
{
    public class LoadNotesCommand : AsyncBaseCommand
    {
        private readonly NotesStore _notesStore;

        public LoadNotesCommand(NotesStore notesStore)
        {
            _notesStore = notesStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _notesStore.LoadAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}