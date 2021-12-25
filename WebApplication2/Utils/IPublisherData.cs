using System.Collections.Generic;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IPublisherData
    {
        void AddPublisher(PublisherDTO publisher);
        List<BookDTO> GetBooks(string publisherName);
    }
}
