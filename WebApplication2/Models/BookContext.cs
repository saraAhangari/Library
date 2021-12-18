using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<AuthorContact> AuthorContact { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
    }
}
