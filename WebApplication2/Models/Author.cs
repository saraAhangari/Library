using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Author
    {
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
