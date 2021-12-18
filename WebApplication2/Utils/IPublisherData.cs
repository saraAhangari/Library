using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public interface IPublisherData
    {
        List<Publisher> GetPublishers();
        Publisher GetPublisher(int id);
        List<Book> GetPublisherBooks(Publisher publisher);

    }
}
