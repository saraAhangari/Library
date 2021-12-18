using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller

    {
        private ICategoryData _categoryData;

        public CategoryController(ICategoryData _categoryData)
        {
            this._categoryData = _categoryData;
        }

        [HttpGet("allcategories")]
        public IActionResult GetCategories()
        {
            return Ok(_categoryData.GetCategories());
        }

        [HttpPost]
        public IActionResult AddBook(BookCategory category)
        {
            _categoryData.AddCategory(category);

            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.Id, category);
        }
    }
}
