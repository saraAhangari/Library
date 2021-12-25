using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IBookDetails
    {
        void AddDetails(BookDetailsDTO detailsDTO);
        BookDetails UpdateDetails(BookDetailsDTO detailsDTO, int id);

    }
}
