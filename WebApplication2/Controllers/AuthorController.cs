using Microsoft.AspNetCore.Mvc;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private IAuthorData _authorData;

        public AuthorController(IAuthorData _authorData)
        {
            this._authorData = _authorData;
        }

        [HttpGet("allauthors")]
        public IActionResult GetAuthors()
        {
            return Ok(_authorData.GetAuthors());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAuthor(int id)
        {
            var author = _authorData.GetAuthor(id);

            if (author != null)
            {
                return Ok(author);
            }

            return NotFound($"The author with id {id} was not found !");
        }

        [HttpGet("{name}/getbyname")]
        public IActionResult GetAuthorByName(string name)
        {
            var author = _authorData.GetAuthorByName(name);

            if (author != null)
            {
                return Ok(author);
            }

            return NotFound($"The author with name: {name} was not found !");
        }

        [HttpGet("{id:int}/authorBooks")]
        public IActionResult GetBooks(string authorName)
        {
            var author = _authorData.GetBooks(authorName);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound($"The author with name {author} does not have any books here !");
        }
    }
}
