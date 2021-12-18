using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public BookCategory Category { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Author> Authors { get; set; }

        //public Book()
        //{
        //    BookAuthors = new HashSet<BookAuthors>();
        //}
    }
}
