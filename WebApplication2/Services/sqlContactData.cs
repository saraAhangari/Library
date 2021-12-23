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
        //public AuthorDetails GetAuthorContact(int id)
        //{
        //    //return _contactContext.AuthorContact.SingleOrDefault(c => c.Id == id);
        //}

        public AuthorDetails UpdateDetails(AuthorDetailsDTO contact)
        {
            var currentDetails = new AuthorDetails();
            //var author = _contactContext.Authors.Find(contact.Id);
            //if (author != null)
            //{
            //    currentDetails.Address = contact.Address;
            //    //currentDetails.ContactNumber = contact.ContactNumber;
            //    _contactContext.AuthorContact.Update(currentDetails);
            //    _contactContext.SaveChanges();
            //}
            return currentDetails;
        }

        public void AddDetails(int id, AuthorDetailsDTO contact)
        {
            AuthorDetails authordetails = new AuthorDetails();
            //authordetails.Id = id;
            //authordetails.ContactNumber = contact.ContactNumber;
            authordetails.Address = contact.Address;
            _contactContext.AuthorContact.Add(authordetails);
            _contactContext.SaveChanges();
        }
    }

}
