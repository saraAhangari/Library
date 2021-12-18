using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class AuthorContact
    {
        [Key]
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
