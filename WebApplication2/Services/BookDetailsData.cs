using WebApplication2.Models;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;

namespace WebApplication2.Services
{
    public class BookDetailsData : IBookDetails
    {
        private LibraryContext _detailsContext;
        bool catFound = false;
        bool pubfound = false;
        bool bookfound = false;

        public BookDetailsData(LibraryContext _detailsContext)
        {
            this._detailsContext = _detailsContext;
        }
        public void AddDetails(BookDetailsDTO detailsDTO)
        {
            BookDetails details = new BookDetails();
            details.bookID = detailsDTO.bookID;
            details.price = detailsDTO.price;


            Publisher pub = new Publisher();
            pub.Name = detailsDTO.publisher;

            foreach (var publisher in _detailsContext.Publishers)
            {
                if (publisher.Name.Equals(detailsDTO.publisher))
                {
                    details.publisherID = publisher.publisherID;
                    pubfound = true;
                    break;
                }
            }
            if (!pubfound)
            {
                details.publisherID = pub.publisherID;
                _detailsContext.Publishers.Add(pub);
            }


            Category cat = new Category();
            cat.Name = detailsDTO.category;

            foreach (var category in _detailsContext.Category)
            {
                if (category.Name.Equals(detailsDTO.category))
                {
                    details.categoryID = category.Id;
                    catFound = true;
                    break;
                }
            }
            if (!catFound)
            {
                details.categoryID = cat.Id;
                _detailsContext.Category.Add(cat);
            }

            foreach (var book in _detailsContext.BookDetails)
            {
                if (book.bookID == detailsDTO.bookID)
                {
                    bookfound = true;
                    details = book;
                    break;
                }
            }
            if (!bookfound)
            {
                _detailsContext.BookDetails.Add(details);
                _detailsContext.SaveChanges();
            }
        }

        public void UpdateDetails(BookDetailsDTO detailsDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
