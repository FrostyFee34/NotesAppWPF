using System;
using System.Threading.Tasks;
using NotesApp.Domain.Commands;
using NotesApp.EF.DTOs;

namespace NotesApp.EF.Commands
{
    public class DeleteNoteCommand : IDeleteNoteCommand
    {
        private readonly NotesAppDbContextFactory _contextFactory;

        public DeleteNoteCommand(NotesAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task Execute(Guid id)
        {
            await using (NotesAppDbContext context = _contextFactory.Create())
            {
                NoteDTO noteDTO = new NoteDTO()
                {
                    Id = id,
                };

                context.Notes.Remove(noteDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}