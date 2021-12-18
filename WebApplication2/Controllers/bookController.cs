using Microsoft.AspNetCore.Mvc;
using WebApplication2.Utils;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class bookController : ControllerBase
    {
        private IbookData _bookData;

        public bookController(IbookData bookData)
        {
            this._bookData = bookData;
        }

        [HttpGet("allbooks")]
        public IActionResult GetBooks()
        {
            return Ok(_bookData.GetBooks());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookData.GetBook(id);

            if (book != null)
            {
                
                return Ok(book);
            }

            return NotFound($"The book with id {id} was not found !");
        }

        [HttpGet("{title}/getbytitle")]
        public IActionResult GetBookByTitle(string title)
        {
            var book = _bookData.GetBookByTitle(title);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound($"The book with title: {title} was not found !");
        }

        [HttpGet("{author}/getbyauthor")]
        public IActionResult GetBookByAuthor(Author author)
        {
            var book = _bookData.GetBookByAuthor(author);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound($"The book with author: {author} was not found !");
        }

        [HttpGet("{publisher}/getbypublisher")]
        public IActionResult GetBookByPublisher(string publisher)
        {
            var book = _bookData.GetBookByPublisher(publisher);

            if (book != null)
                return Ok(book);

            return NotFound($"The book with publisher: {publisher} was not found !");
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookData.AddBook(book);

            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + book.Id, book);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookData.GetBook(id);
            if (book != null)
            {
                _bookData.DeleteBook(book);
                //return Ok(book)
            }

            return NotFound($"The book with id: {id} was not found !");
        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdateBook(Book book, int id)
        {
            var currentBook = _bookData.GetBook(id);
            if (currentBook != null)
            {
                book.Id = currentBook.Id;
                _bookData.UpdateBook(book);
            }
            return Ok(book);
        }
    }
}
