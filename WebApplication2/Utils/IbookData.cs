using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public interface IbookData
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book GetBookByTitle(string title);
        List<Book> GetBookByAuthor(string author);
        List<Book> GetBookByPublisher(string publisher);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
