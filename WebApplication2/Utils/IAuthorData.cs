using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IAuthorData
    {
        void AddAuthor(AuthorDTO authorDTO);
        List<Author> GetAuthors();
        Author GetAuthor(int id);
        Author GetAuthorByName(string name);
        //List<Book> GetBooks(Author author);
    }
}
