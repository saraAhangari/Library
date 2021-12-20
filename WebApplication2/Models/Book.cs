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
        public string Category { get; set; }
        public Publisher publisher { get; set; } // one to many
        public ICollection<Author> authorsList { get; set; } // many - to - many

        public void setAuthors(IList<Author> author)
        {
            this.authorsList = author;
        }

        public void setPublisher(Publisher publisher)
        {
            this.publisher = publisher;
        }

    }
}
