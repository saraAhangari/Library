using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ModelsDTO
{
    public class PublisherDTO
    {
        [Key]
        public int publisherID { get; set; }
        public string Name { get; set; }
        public Book book { get; set; } // one to many
    }
}
