using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //one to one 
        public AuthorDetails AuthorContact { get; set; } 
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}
