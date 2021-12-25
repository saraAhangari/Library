using Microsoft.AspNetCore.Mvc;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookDetailsController : Controller
    {
        private IBookDetails _detailsData;

        public BookDetailsController(IBookDetails _detailsData)
        {
            this._detailsData = _detailsData;
        }

        [HttpPost]
        public IActionResult AddDetails(BookDetailsDTO dto)
        {
            _detailsData.AddDetails(dto);
            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + dto.bookID, dto);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateDetails(BookDetailsDTO detailsDTO, int id)
        {
            var details = _detailsData.UpdateDetails(detailsDTO, id);
            if (details != null)
            {
                return Ok(detailsDTO);
            }
            return NotFound($"The book with id {id} was not found !");
        }
    }
}
