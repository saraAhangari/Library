using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public class sqlBookData : IbookData
    {
        private BookContext _bookContext;
        public sqlBookData(BookContext bookContext)
        {
            this._bookContext = bookContext;
        }
        public Book AddBook(Book book)
        {
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
            return book;
        }

        public void DeleteBook(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }

        public Book GetBook(int id)
        {
            return _bookContext.Books.SingleOrDefault(b => b.id == id);
        }

        public List<Book> GetBookByAuthor(string author)
        {
            return _bookContext.Books.Where(b => b.author == author).ToList();
        }

        public List<Book> GetBookByPublisher(string publisher)
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
            var currentBook = _bookContext.Books.Find(book.id);
            if (currentBook != null)
            {
                currentBook.title = book.title;
                currentBook.author = book.author;
                currentBook.publisher = book.publisher;
                _bookContext.Books.Update(currentBook);
                _bookContext.SaveChanges();
            }
            return book;
        }
    }
}
