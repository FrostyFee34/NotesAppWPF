using System;
using NotesApp.WPF.ViewModels;

namespace NotesApp.WPF.Stores
{
    public class ModalNavigationStore
    {
        private BaseViewModel _currentViewModel;
        public bool IsOpen => CurrentViewModel != null;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                CurrentModelChanged?.Invoke();
            }
        }

        public event Action CurrentModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}