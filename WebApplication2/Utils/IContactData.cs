using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public interface IContactData
    {
        AuthorDetails GetAuthorContact(int id);
        AuthorDetails UpdateDetails(ContactDTO Contactdto);
        void AddDetails(int id, ContactDTO contact);
    }
}
