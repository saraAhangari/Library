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
            if (_detailsContext.Books.Find(detailsDTO.bookID) != null)
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
                        pub = publisher;
                        pubfound = true;
                        break;
                    }
                }
                if (pubfound)
                    details.publisherID = _detailsContext.Publishers.Find(pub.publisherID).publisherID;
                else
                {
                    _detailsContext.Publishers.Add(pub);
                    _detailsContext.SaveChanges();
                    details.publisherID = _detailsContext.Publishers.Find(pub.publisherID).publisherID;

                }


                Category cat = new Category();
                cat.Name = detailsDTO.category;

                foreach (var category in _detailsContext.Category)
                {
                    if (category.Name.Equals(detailsDTO.category))
                    {
                        cat = category;
                        catFound = true;
                        break;
                    }
                }
                if (catFound)
                    details.categoryID = _detailsContext.Category.Find(cat.Id).Id;
                else
                {
                    _detailsContext.Category.Add(cat);
                    _detailsContext.SaveChanges();
                    details.categoryID = _detailsContext.Category.Find(cat.Id).Id;
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
        }

        public BookDetails UpdateDetails(BookDetailsDTO details, int id)
        {
            using (var ct = new LibraryContext())
            {
                var currentDetails = _detailsContext.BookDetails.Find(id);
                if (currentDetails != null)
                {
                    currentDetails.price = details.price;
                    currentDetails.bookID = details.bookID;
                    currentDetails.fileId = id;

                    Category bookCategory = new Category();
                    bookCategory.Name = details.category;
                    foreach (var category in _detailsContext.Category)
                    {
                        if (category.Name.Equals(details.category))
                        {
                            currentDetails.categoryID = category.Id;
                            catFound = true;
                            break;
                        }
                    }
                    if (!catFound)
                    {
                        currentDetails.categoryID = bookCategory.Id;
                        _detailsContext.Category.Add(bookCategory);
                    }


                    Publisher bookPublisher = new Publisher();
                    bookPublisher.Name = details.publisher;
                    foreach (var publisher in _detailsContext.Publishers)
                    {
                        if (publisher.Name.Equals(details.publisher))
                        {
                            currentDetails.publisherID = publisher.publisherID;
                            pubfound = true;
                            break;
                        }
                    }
                    if (!pubfound)
                    {
                        currentDetails.publisherID = bookPublisher.publisherID;
                        _detailsContext.Publishers.Add(bookPublisher);
                    }
                    ct.BookDetails.Update(currentDetails);
                    ct.SaveChanges();
                }
                return currentDetails;
            }
        }
    }
}
