using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;
using NotesApp.Domain.Queries;
using NotesApp.EF.DTOs;

namespace NotesApp.EF.Queries
{
    public class GetAllNotesQuery : IGetAllNotesQuery
    {
        private readonly NotesAppDbContextFactory _contextFactory;

        public GetAllNotesQuery(NotesAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Note>> Execute()
        {
            await using (NotesAppDbContext context = _contextFactory.Create())
            {
                IEnumerable<NoteDTO> noteDtos = await context.Notes.ToListAsync();

                return noteDtos.Select(n => new Note(n.Id, n.Header, n.Content, n.IsDone, n.Deadline));
            }
        }
    }
}