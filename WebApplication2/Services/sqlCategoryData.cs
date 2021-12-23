using WebApplication2.Models;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;

namespace WebApplication2.Services
{
    public class sqlCategoryData : ICategoryData
    {
        private LibraryContext _Context;

        public sqlCategoryData(LibraryContext _Context)
        {
            this._Context = _Context;
        }

        public void AddCategory(CategoryDTO category)
        {
            Category cat = new Category();
            cat.Name = category.Name;

            _Context.Category.Add(cat);
            _Context.SaveChanges();
        }
    }
}
