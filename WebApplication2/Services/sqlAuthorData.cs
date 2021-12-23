using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Utils
{
    public class sqlAuthorData : IAuthorData
    {
        private LibraryContext _authorContext;

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


            _authorContext.Authors.Add(author);
            _authorContext.SaveChanges();
        }

        public Author GetAuthor(int id)
        {
            return _authorContext.Authors.SingleOrDefault(a => a.Id == id);
        }

        public Author GetAuthorByName(string name)
        {
            return _authorContext.Authors.SingleOrDefault(a => a.Firstname == name);
        }

        public List<Author> GetAuthors()
        {
            return _authorContext.Authors.ToList();
        }

        //public List<Book> GetBooks(Author author)
        //{
        //    return _authorContext.Books.Where(b => b.author == author).ToList();
        //}
    }
}
