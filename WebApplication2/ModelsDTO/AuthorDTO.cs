using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ModelsDTO
{
    public class AuthorDTO
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //one to one 
        public AuthorDetails AuthorContact { get; set; } 
        public ICollection<Book> Books { get; set; }

        public AuthorDTO()
        {
            Books = new List<Book>();
        }
    }
}
