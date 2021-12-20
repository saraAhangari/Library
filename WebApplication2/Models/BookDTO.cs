using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class BookDTO
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string Category { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public PublisherDTO Publisher { get; set; } // one to many
        public ICollection<AuthorDTO> authors { get; set; } // many - to - many

      
        //public BookDTO(Book b)
        //{
        //    Id = b.Id;
        //    title = b.title;
        //    //author = b.author;
        //    //Publisher = b.Publisher;

        //    //authorName = string.Format("",author);
        //    //publisherName = string.Format("", Publisher);
        //}

    }
}
