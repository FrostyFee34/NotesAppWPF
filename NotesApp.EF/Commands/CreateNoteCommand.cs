using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Commands;
using NotesApp.Domain.Models;
using NotesApp.EF.DTOs;

namespace NotesApp.EF.Commands
{
    public class CreateNoteCommand : ICreateNoteCommand
    {
        private readonly NotesAppDbContextFactory _contextFactory;

        public CreateNoteCommand(NotesAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Note note)
        {
            await using (NotesAppDbContext context = _contextFactory.Create())
            {
                NoteDTO noteDTO = new NoteDTO()
                {
                    Id = note.Id,
                    Content = note.Content,
                    Deadline = note.Deadline,
                    Header = note.Header,
                    IsDone = note.IsDone,
                };

                context.Notes.Add(noteDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}