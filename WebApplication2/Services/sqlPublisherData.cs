using WebApplication2.Models;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;

namespace WebApplication2.Services
{
    public class sqlPublisherData : IPublisherData
    {
        private LibraryContext _Context;
        bool found = false;
        public sqlPublisherData(LibraryContext _Context)
        {
            this._Context = _Context;
        }

        public void AddPublisher(PublisherDTO dto)
        { 
            Publisher publisher = new Publisher();
            publisher.Name = dto.Name;
            foreach(var pub in _Context.Publishers)
            {
                if(pub.Name == dto.Name)
                {
                    publisher = pub;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                _Context.Publishers.Add(publisher);
                _Context.SaveChanges();
            }
        }
    }
}
