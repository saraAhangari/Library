using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IContactData
    {
        void UpdateDetails(AuthorDetailsDTO Contactdto, int id);
    }
}
