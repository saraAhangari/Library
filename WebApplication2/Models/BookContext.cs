using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasKey(sc => new { sc.Id, sc.publisher });
            //modelBuilder.Ignore<Publisher>();
            //Book
            //modelBuilder.Entity<Book>().HasKey(x => x.Id);
            //modelBuilder.Entity<Book>().Property(x => x.title).IsRequired();

            ////Author
            //modelBuilder.Entity<Author>().HasKey(x => x.Id);
            //modelBuilder.Entity<Author>().Property(x => x.Name).IsRequired();

            //modelBuilder.Entity<Book>().HasMany(
            //       x => x.author).WithMany(x => x.Books).
            //       UsingEntity<Dictionary<string, object>>(
            //           "BookAuthor",
            //           b => b.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
            //           b => b.HasOne<Book>().WithMany().HasForeignKey("BookId"));
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorContact> AuthorContact { get; set; }
        public DbSet<Publisher> Library { get; set; }
    }
}
