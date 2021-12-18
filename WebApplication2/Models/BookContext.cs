using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>()
        //        .HasMany(s => s.).WithMany(c => ‎c.).Map(c ‎‎=>‎
        //‎        {‎
        //‎            c.MapLeftKey("book_id");‎
        //‎            c.MapRightKey("library_id");‎
        //‎            c.ToTable("bookandlibrary");‎
        //‎        });‎
        //‎        base.OnModelCreating(modelBuilder);‎
                
        //}
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorContact> AuthorContact { get; set; }
    }
}
