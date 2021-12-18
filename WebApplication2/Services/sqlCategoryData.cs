using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Utils;

namespace WebApplication2.Services
{
    public class sqlCategoryData : ICategoryData
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

        public BookCategory AddCategory(BookCategory category)
        {
            _categoryContext.BookCategory.Add(category);
            _categoryContext.SaveChanges();
            return category;
        }
    }
}
