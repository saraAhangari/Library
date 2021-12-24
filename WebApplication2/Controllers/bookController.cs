using Microsoft.AspNetCore.Mvc;
using WebApplication2.Utils;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class bookController : ControllerBase
    {
        private IBookData _bookData;  

        public bookController(IBookData bookData)
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

        //[HttpGet("{author}/getbyauthor")]
        //public IActionResult GetBookByAuthor(Author author)
        //{
        //    var book = _bookData.GetBookByAuthor(author);

        //    if (book != null)
        //    {
        //        return Ok(book);
        //    }

        //    return NotFound($"The book with author: {author} was not found !");
        //}

        //[HttpGet("{publisher}/getbypublisher")]
        //public IActionResult GetBookByPublisher(Publisher publisher)
        //{
        //    var book = _bookData.GetBookByPublisher(publisher);

        //    if (book != null)
        //        return Ok(book);

        //    return NotFound($"The book with publisher: {publisher} was not found !");
        //}

        [HttpPost]
        public IActionResult AddBook(BookDTO dto)
        {
           _bookData.AddBook(dto);
            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + dto.title, dto);
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
        public IActionResult UpdateDetails(BookUpdateDTO book)
        {
            var currentBook = _bookData.GetBook(book.Id);
            if (currentBook != null)
            {
                book.Id = currentBook.Id;
                _bookData.UpdateBook(book);
            }
            return Ok(book);
        }
    }
}
