using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public class sqlContactData : IContactData
    {
        private BookContext _contactContext;

        public sqlContactData(BookContext _contactContext)
        {
            this._contactContext = _contactContext;
        }
        public AuthorContact GetAuthorContact(int id)
        {
            return _contactContext.AuthorContact.SingleOrDefault(c => c.Id == id);
        }
    }

}
