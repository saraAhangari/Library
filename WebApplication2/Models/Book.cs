using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public IList<Author> author { get; set; }

    }
}
