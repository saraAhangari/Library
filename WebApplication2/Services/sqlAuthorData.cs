using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public class sqlAuthorData : IAuthorData
    {
        private LibraryContext _authorContext;
        bool found=false;

        public sqlAuthorData(LibraryContext _authorContext)
        {
            this._authorContext = _authorContext;
        }

        public void AddAuthor(AuthorDTO authorDTO)
        {
            AuthorDetails authorDetails = new AuthorDetails();
            authorDetails = authorDTO.details;


            Author author = new Author();
            author.Firstname = authorDTO.Firstname;
            author.Lastname = authorDTO.Lastname;
            author.AuthorContact = authorDetails;

            foreach(var author2 in _authorContext.Authors)
            {
                if(author2.Firstname.Equals(author.Firstname)
                    && author2.Lastname.Equals(author.Lastname))
                {
                    found = true;
                    author = author2;
                    break;
                }
            }
            if (!found)
            {
                _authorContext.Authors.Add(author);
                _authorContext.SaveChanges();
            }
        }

        public AuthorDTO GetAuthor(int id)
        {
            var author = _authorContext.Authors.SingleOrDefault(b => b.Id == id);
            if (author != null)
            {
                AuthorDTO dTO = new AuthorDTO();
                dTO.Firstname = author.Firstname;
                dTO.Lastname = author.Lastname;
                foreach (var detail in _authorContext.AuthorContact)
                {
                    if (detail.AuthorId == id)
                        dTO.details = detail;
                }
                return dTO;
            }
            return null;
        }

        public Author GetAuthorByName(string lastname)
        {
            return _authorContext.Authors.SingleOrDefault(a => a.Lastname == lastname);
        }

        public List<AuthorDTO> GetAuthors()
        {
            List<Author> authors = _authorContext.Authors.ToList();
            List<AuthorDTO> authorsDTO = new List<AuthorDTO>();
            foreach (var author1 in authors)
            {
                AuthorDTO dTO = new AuthorDTO();
                dTO.Firstname = author1.Firstname;
                dTO.Lastname = author1.Lastname;
                foreach (var detail in _authorContext.AuthorContact)
                {
                    if (detail.AuthorId == author1.Id)
                        dTO.details = detail;
                }

                authorsDTO.Add(dTO);
            }
            return authorsDTO;
        }

        public List<BookDTO> GetBooks(string authorname)
        {
            var author = GetAuthorByName(authorname);
            var books = new List<Book>();
            List<BookDTO> booksDTO = new List<BookDTO>();
            books = _authorContext.Books.Where(b => b.authors.Contains(author)).ToList();
            foreach (var book in books)
            {
                BookDTO dTO = new BookDTO();
                dTO.title = book.title;

                List<Publisher> publisher = _authorContext.Publishers.Where(p => p.book.Contains(book))
                                                                    .ToList();
                List<Author> authors = _authorContext.Authors.Where(a => a.Books.Contains(book))
                                                           .ToList();
                book.publisher = publisher;
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
                    foreach (var detail in _authorContext.AuthorContact)
                    {
                        if (detail.AuthorId == author.Id)
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
