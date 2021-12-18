using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual AuthorContact AuthorContact { get; set; }
        public virtual ICollection<BookAuthors> BookAuthors { get; set; }

        public Author()
        {
            BookAuthors = new HashSet<BookAuthors>();
        }

    }
}
