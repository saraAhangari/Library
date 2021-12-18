using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public interface ICategoryData
    {
        List<BookCategory> GetCategories();
        BookCategory AddCategory(BookCategory category);

    }
}
