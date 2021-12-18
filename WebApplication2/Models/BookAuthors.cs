namespace WebApplication2.Models
{
    public class BookAuthors
    {
        public string BookId { get; set; }
        public string AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
