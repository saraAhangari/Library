using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IBookData
    {
        BookDTO GetBook(int id);
        BookDTO GetBookByTitle(string title);
        List<BookDTO> GetBooks();
        void AddBook(BookDTO book);
        void UpdateBook(BookDTO book, int id);
        void DeleteBook(int id);
    }
}
