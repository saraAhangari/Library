using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ModelsDTO
{
    public class AuthorDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public AuthorDetails details { get; set; }
    }
}
