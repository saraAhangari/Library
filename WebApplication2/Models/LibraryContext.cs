using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace WebApplication2.Models
{
    public class LibraryContext : DbContext
    {
        //public BookContext(DbContextOptions options) : base(options)
        //{
        //}
        public LibraryContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-25LABC3; database=dbLibrary; trusted_connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetails> AuthorContact { get; set; }
    }
}
