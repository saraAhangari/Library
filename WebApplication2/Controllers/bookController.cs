﻿using Microsoft.AspNetCore.Mvc;
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
                _bookData.DeleteBook(id);
                //return Ok(book)
            }

            return NotFound($"The book with id: {id} was not found !");
        }

        [HttpPut]
        public IActionResult UpdateDetails(BookDTO book , int id)
        {
            var currentBook = _bookData.GetBook(id);
            if (currentBook != null)
            {
                _bookData.UpdateBook(book , id);
            }
            return Ok(book);
        }
    }
}
