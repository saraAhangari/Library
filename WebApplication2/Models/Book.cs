using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string publisher { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }
}
