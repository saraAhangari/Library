using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public interface IAuthorData
    {
        List<Author> GetAuthors();
        Author GetAuthor(int id);
        Author GetAuthorByName(string name);
        //List<Book> GetBooks(Author author);
    }
}
