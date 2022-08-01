using System.Collections.Generic;
using System.Threading.Tasks;
using NotesApp.Domain.Models;

namespace NotesApp.Domain.Queries
{
    public interface IGetAllNotesQuery
    {
        Task<IEnumerable<Note>> Execute();
    }
}