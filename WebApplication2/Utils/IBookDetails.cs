using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IBookDetails
    {
        void AddDetails(BookDetailsDTO detailsDTO);
        void UpdateDetails(BookDetailsDTO detailsDTO, int id);

    }
}
