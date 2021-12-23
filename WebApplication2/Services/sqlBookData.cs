using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public class sqlBookData : IbookData
    {
        private LibraryContext _bookContext;
        public sqlBookData(LibraryContext bookContext)
        {
            this._bookContext = bookContext;
        }
        public void AddBook(BookDTO dto)
        {
            //PROBLEM => NOT BEING ABLE TO INSERT DUPLICATE PUBLISHERID
            //PROBLEM => NOT BEING ABLE TO INSERT DUPLICATE author
            using (var ct = new LibraryContext()) 
            {
                Publisher publisher = new Publisher() { Id = dto.Publisher.Id };

                var book =
                new Book()
                {
                    Id = dto.Id,
                    title = dto.title,
                    Category = dto.Category,
                    publisher = publisher
                };
           
                ct.Books.Add(book);
                ct.SaveChanges();
            }
            

           /* Author author = new Author(){ Name = dto.author.Name };

            var loadbooks = _bookContext.Books.Include(b => b.authorsList).ToList();
            var loadauthors = _bookContext.Authors.Include(b => b.Books).ToList();
            _bookContext.Books.AddRange(book);
            _bookContext.Authors.Add(author);
            _bookContext.Publishers.Add(publisher);
            _bookContext.SaveChanges();*/
        }
      

        public void DeleteBook(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }

        public Book GetBook(int id)
        {
            return _bookContext.Books.SingleOrDefault(b => b.Id == id);
        }

        public List<Book> GetBookByAuthor(Author author)
        {
            return _bookContext.Books.Where(b => b.authorsList.Contains(author)).ToList();
        }

        public List<Book> GetBookByPublisher(Publisher publisher)
        {
            return _bookContext.Books.Where(b => b.publisher == publisher).ToList();
        }

        public Book GetBookByTitle(string title)
        {
            return _bookContext.Books.SingleOrDefault(b => b.title == title);
        }

        public List<Book> GetBooks()
        {
            return _bookContext.Books.ToList();
        }

        public Book UpdateBook(Book book)
        {
            var currentBook = _bookContext.Books.Find(book.Id);
            if (currentBook != null)
            {
                currentBook.title = book.title;
                //currentBook.author = book.author;
                //currentBook.Publisher = book.Publisher;
                _bookContext.Books.Update(currentBook);
                _bookContext.SaveChanges();
            }
            return book;
        }
    }
}
