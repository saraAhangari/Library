using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public interface IAuthorData
    {
        void AddAuthor(AuthorDTO authorDTO);
        List<AuthorDTO> GetAuthors();
        AuthorDTO GetAuthor(int id);
        Author GetAuthorByName(string Lastname);
        List<BookDTO> GetBooks(string author);
    }
}
