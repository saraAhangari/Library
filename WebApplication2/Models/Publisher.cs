namespace WebApplication2.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new HashSet<Book>();
        }
    }
}
