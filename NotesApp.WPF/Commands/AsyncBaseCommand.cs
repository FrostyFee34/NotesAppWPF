using System;
using System.Threading.Tasks;

namespace NotesApp.WPF.Commands
{
    public abstract class AsyncBaseCommand : BaseCommand
    {
        public override async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception e)
            {
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}