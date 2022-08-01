using NotesApp.WPF.Stores;

namespace NotesApp.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ModalNavigationStore _modalNavigationStore;


        public MainViewModel(ModalNavigationStore modalNavigationStore, NotesViewModel notesViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            NotesViewModel = notesViewModel;

            _modalNavigationStore.CurrentModelChanged += ModalNavigationStoreOnCurrentModelChanged;
        }

        public BaseViewModel CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public NotesViewModel NotesViewModel { get; }

        private void ModalNavigationStoreOnCurrentModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentModelChanged -= ModalNavigationStoreOnCurrentModelChanged;
            base.Dispose();
        }
    }
}