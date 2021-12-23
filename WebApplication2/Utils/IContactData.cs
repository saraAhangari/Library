using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IContactData
    {
        //AuthorDetails GetAuthorContact(int id);
        AuthorDetails UpdateDetails(AuthorDetailsDTO Contactdto);
        void AddDetails(int id, AuthorDetailsDTO contact);
    }
}
