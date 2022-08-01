using System;
using System.Windows.Input;

namespace NotesApp.WPF.ViewModels
{
    public class NoteDetailsFormViewModel : BaseViewModel
    {
        private string _content;
        private string _header;
        private bool _isDone;
        private DateTime? _deadline;

        public NoteDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }


        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged(nameof(Header));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public DateTime? Deadline
        {
            get => _deadline ?? DateTime.Now;
            set
            {
                _deadline = value;
                OnPropertyChanged(nameof(Deadline));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Header);
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
    }
}