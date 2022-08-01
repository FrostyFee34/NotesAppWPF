using System;
using System.Windows.Input;

namespace NotesApp.WPF.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        protected virtual void OnExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public abstract void Execute(object parameter);
        public event EventHandler CanExecuteChanged;
    }
}