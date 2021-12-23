using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ModelsDTO
{
    public class BookDTO
    {
        public string title { get; set; }
      
        public PublisherDTO publisher { get; set; } // one to many
        public ICollection<AuthorDTO> authors { get; set; } // many to many

        public BookDTO()
        {
            authors = new List<AuthorDTO>();
        }

    }
}
