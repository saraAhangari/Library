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
            //modelBuilder.Entity<Book>().HasKey(sc => new { sc.Id, sc.publisher });
            //modelBuilder.Ignore<Publisher>();


            //Book
            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().Property(x => x.title).IsRequired();

            //Author
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Author>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Book>()
                .HasMany(x => x.authorsList)
                .WithMany(x => x.Books)
                .UsingEntity<Dictionary<string, object>>(
                       "BookAuthor",
                       b => b.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                       b => b.HasOne<Book>().WithMany().HasForeignKey("BookId"));


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetails> AuthorContact { get; set; }
    }
}
