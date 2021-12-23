using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IbookData
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book GetBookByTitle(string title);
        //List<Book> GetBookByAuthor(Author author);
        List<Book> GetBookByPublisher(Publisher publisher);
        void AddBook(BookDTO book);
        Book UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
