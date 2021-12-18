using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        public IList<Book> book { get; set; }
    }
}
