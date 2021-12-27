using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Publisher
    {
        [Key]
        public int publisherID { get; set; }
        public string Name { get; set; }
        public ICollection<Book> book { get; set; } 

        public Publisher()
        {
            book = new List<Book>();
        }
    }
}
