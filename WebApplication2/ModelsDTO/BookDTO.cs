using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ModelsDTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public PublisherDTO publisher { get; set; } 
        public ICollection<AuthorDTO> authors { get; set; }

        public BookDTO()
        {
            authors = new List<AuthorDTO>();
        }

    }
}
