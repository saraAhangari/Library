using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ModelsDTO
{
    public class BookDTO
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
      
        public ICollection<Publisher> publisher { get; set; } // one to many
        public ICollection<Author> authors { get; set; } // many to many

        public BookDTO()
        {
            publisher = new List<Publisher>();
            authors = new List<Author>();
        }

    }
}
