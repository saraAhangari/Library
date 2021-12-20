using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class AuthorDTO
    {
        public string Name { get; set; }

        public string getName()
        {
            return Name;
        }


    }
}
