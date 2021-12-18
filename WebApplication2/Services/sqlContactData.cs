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

        public AuthorContact UpdateDetails(AuthorContact contact)
        {
            var currentDetails = _contactContext.AuthorContact.Find(contact.Id);
            if (currentDetails != null)
            {
                currentDetails.Address = contact.Address;
                currentDetails.ContactNumber = contact.ContactNumber;
                _contactContext.AuthorContact.Update(currentDetails);
                _contactContext.SaveChanges();
            }
            return contact;
        }
    }

}
