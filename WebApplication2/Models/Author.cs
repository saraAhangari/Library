using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorContact AuthorContact { get; set; } // one - to - one
        public ICollection<Book> Books { get; set; }

        public void setName(string name)            
        {
            this.Name = name;
        }

        public void setBooks(ICollection<Book> books)
        {
            this.Books = books;
        }
    }
}
