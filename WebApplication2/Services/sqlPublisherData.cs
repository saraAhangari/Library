using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Services
{
    public class sqlPublisherData
    {
        private LibraryContext _Context;
        public sqlPublisherData(LibraryContext _Context)
        {
            this._Context = _Context;
        }

        public void AddPublisher(PublisherDTO dto)
        { 
            Publisher publisher = new Publisher();
            publisher.Name = dto.Name;

            _Context.Publishers.Add(publisher);
            _Context.SaveChanges();
        }
    }
}
