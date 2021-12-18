using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class sqlPublisherData
    {
        private BookContext _publisherContext;
        public sqlPublisherData(BookContext _publisherContext)
        {
            this._publisherContext = _publisherContext;
        }

        public List<Publisher> GetPublishers()
        {
            return _publisherContext.Publishers.ToList();       
        }
        public Publisher GetPublisher(int id)
        {
            return _publisherContext.Publishers.SingleOrDefault(p => p.Id == id);
        }
        public List<Book> GetPublisherBooks(Publisher publisher)
        {
            return _publisherContext.Books.Where(b => b.Publisher == publisher).ToList();
        }
    }
}
