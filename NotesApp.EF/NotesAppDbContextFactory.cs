using Microsoft.EntityFrameworkCore;

namespace NotesApp.EF
{
    public class NotesAppDbContextFactory
    {
        private readonly DbContextOptions _options;

        public NotesAppDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public NotesAppDbContext Create()
        {
            return new NotesAppDbContext(_options);
        }
    }
}