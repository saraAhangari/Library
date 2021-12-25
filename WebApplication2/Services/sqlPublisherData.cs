using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;
using System.Linq;

namespace WebApplication2.Services
{
    public class sqlPublisherData : IPublisherData
    {
        private LibraryContext _Context;
        bool found = false;
        public sqlPublisherData(LibraryContext _Context)
        {
            this._Context = _Context;
        }

        public void AddPublisher(PublisherDTO dto)
        { 
            Publisher publisher = new Publisher();
            publisher.Name = dto.Name;
            foreach(var pub in _Context.Publishers)
            {
                if(pub.Name == dto.Name)
                {
                    publisher = pub;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                _Context.Publishers.Add(publisher);
                _Context.SaveChanges();
            }
        }

        public List<BookDTO> GetBooks(string publisherName)
        {
            var publisher = _Context.Publishers.SingleOrDefault(p => p.Name == publisherName);
            var books = new List<Book>();
            List<BookDTO> booksDTO = new List<BookDTO>();
            books = _Context.Books.Where(b => b.publisher.Contains(publisher)).ToList();
            foreach (var book in books)
            {
                BookDTO dTO = new BookDTO();
                dTO.Id = book.Id;
                dTO.title = book.title;

                List<Publisher> publishers = _Context.Publishers.Where(p => p.book.Contains(book))
                                                                    .ToList();
                List<Author> authors = _Context.Authors.Where(a => a.Books.Contains(book))
                                                           .ToList();
                book.publisher = publishers;
                book.authors = authors;

                foreach (var pub in book.publisher)
                {
                    PublisherDTO publisherDTO = new PublisherDTO();
                    publisherDTO.Name = pub.Name;
                    dTO.publisher = publisherDTO;
                }


                foreach (var bookauthor in book.authors)
                {
                    AuthorDTO authorDTO = new AuthorDTO();
                    authorDTO.Firstname = bookauthor.Firstname;
                    authorDTO.Lastname = bookauthor.Lastname;
                    foreach (var detail in _Context.AuthorContact)
                    {
                        if (detail.AuthorId == bookauthor.Id)
                            authorDTO.details = detail;

                    }
                    dTO.authors.Add(authorDTO);
                }
                booksDTO.Add(dTO);
            }
            return booksDTO;
        }
    }
}
