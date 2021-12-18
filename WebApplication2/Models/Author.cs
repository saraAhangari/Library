using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public AuthorContact AuthorContact { get; set; }
        public ICollection<Book> books { get;}

        //public Author()
        //{
        //    BookAuthors = new HashSet<BookAuthors>();
        //}

    }
}
