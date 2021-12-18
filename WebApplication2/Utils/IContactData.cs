using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public interface IContactData
    {
        AuthorContact GetAuthorContact(int id);
        AuthorContact AddDetails(AuthorContact authorContact);
    }
}
