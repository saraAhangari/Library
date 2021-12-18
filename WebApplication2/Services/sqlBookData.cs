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
        public void AddBook(Book book)
        {
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _bookContext.Books.Remove(book);
            foreach (Author author in _bookContext.Authors)
            {
                if (author == book.author)
                {
                    _bookContext.Authors.Remove(author);
                }
            }
            _bookContext.SaveChanges();
        }

        public Book GetBook(int id)
        {
            return _bookContext.Books.SingleOrDefault(b => b.Id == id);
        }

        public List<Book> GetBookByAuthor(Author author)
        {
            return _bookContext.Books.Where(b => b.author == author).ToList();
        }

        public List<Book> GetBookByPublisher(string publisher)
        {
            return _bookContext.Books.Where(b => b.Publisher == publisher).ToList();
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
                currentBook.author = book.author;
                currentBook.Publisher = book.Publisher;
                _bookContext.Books.Update(currentBook);
                _bookContext.SaveChanges();
            }
            return book;
        }
    }
}
