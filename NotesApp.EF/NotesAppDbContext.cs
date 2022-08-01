using Microsoft.EntityFrameworkCore;
using NotesApp.EF.DTOs;

namespace NotesApp.EF
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NoteDTO> Notes { get; set; }
    }
}