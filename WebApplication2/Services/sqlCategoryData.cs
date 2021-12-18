using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class sqlCategoryData
    {
        private BookContext _categoryContext;

        public sqlCategoryData(BookContext _categoryContext)
        {
            this._categoryContext = _categoryContext;
        }

        public List<BookCategory> GetCategories()
        {
            return _categoryContext.BookCategory.ToList();
        }

        public BookCategory AddBook(BookCategory category)
        {
            _categoryContext.BookCategory.Add(category);
            _categoryContext.SaveChanges();
            return category;
        }
    }
}
