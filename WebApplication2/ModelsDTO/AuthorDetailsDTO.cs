using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.ModelsDTO
{
    public class AuthorDetailsDTO
    {
        [Key]
        public int fileId { get; set; }
        public int AuthorId { get; set; } //one to one 
        public int age { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }

    }
}
