using System.Threading.Tasks;
using NotesApp.Domain.Models;

namespace NotesApp.Domain.Commands
{
    public interface IUpdateNoteCommand
    {
        Task Execute(Note note);
    }
}