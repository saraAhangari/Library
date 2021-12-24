using WebApplication2.Models;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;

namespace WebApplication2.Services
{
    public class BookDetailsData : IBookDetails
    {
        private LibraryContext _detailsContext;

        public BookDetailsData(LibraryContext _detailsContext)
        {
            this._detailsContext = _detailsContext;
        }
        public void AddDetails(BookDetailsDTO detailsDTO)
        {
            BookDetails details = new BookDetails();
            details.bookID = detailsDTO.bookID;
            details.price = detailsDTO.price;

            foreach (var publisher in _detailsContext.Publishers)
            {
                if (publisher.Name.Equals(detailsDTO.publisher))
                {
                    details.publisherID = publisher.publisherID;
                }
            }

            foreach (var category in _detailsContext.Category)
            {
                if (category.Name.Equals(detailsDTO.category))
                {
                    details.categoryID = category.Id;
                }
            }

            _detailsContext.BookDetails.Add(details);
            _detailsContext.SaveChanges();
        }

        public void UpdateDetails(BookDetailsDTO detailsDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
