using System.Linq;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public class sqlContactData : IContactData
    {
        private LibraryContext _contactContext;

        public sqlContactData(LibraryContext _contactContext)
        {
            this._contactContext = _contactContext;
        }

        public AuthorDetails UpdateDetails(AuthorDetailsDTO contact , int id)
        {
            using(var ct = new LibraryContext())
            {
                var currentDetails = _contactContext.AuthorContact.SingleOrDefault(i => i.fileId == id);
                if (currentDetails != null)
                {
                    currentDetails.age = contact.age;
                    currentDetails.Address = contact.Address;
                    currentDetails.Number = contact.Number;
                    currentDetails.fileId = id;
                    currentDetails.AuthorId = contact.AuthorID;
                    ct.AuthorContact.Update(currentDetails);
                    ct.SaveChanges();
                }
                return currentDetails;
            }
        }
    }

}
