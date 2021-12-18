using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public class sqlAuthorData : IAuthorData
    {
        private BookContext _authorContext;

        public sqlAuthorData(BookContext _authorContext)
        {
            this._authorContext = _authorContext;
        }
        public Author GetAuthor(int id)
        {
            return _authorContext.Authors.SingleOrDefault(a => a.Id == id);
        }

        public Author GetAuthorByName(string name)
        {
            return _authorContext.Authors.SingleOrDefault(a => a.Name == name);
        }

        public List<Author> GetAuthors()
        {
            return _authorContext.Authors.ToList();
        }

        public List<Book> GetBooks(string authorName)
        {
            return _authorContext.Books.Where(b => b.author == authorName).ToList();
        }
    }
}
