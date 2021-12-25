using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public ICollection<Publisher> publisher { get; set; } 
        public ICollection<Author> authors { get; set; } 

        public Book()
        {
            publisher = new List<Publisher>();
            authors = new List<Author>();
        }

    }
}
