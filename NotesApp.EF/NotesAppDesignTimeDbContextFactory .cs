using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NotesApp.EF
{
    public class NotesAppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<NotesAppDbContext>
    {
        public NotesAppDbContext CreateDbContext(string[] args = null)
        {
            return new NotesAppDbContext(new DbContextOptionsBuilder().UseSqlite("Data source=NotesApp.db").Options);
        }
    }
}