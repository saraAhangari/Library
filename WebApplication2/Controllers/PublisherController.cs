using Microsoft.AspNetCore.Mvc;
using WebApplication2.ModelsDTO;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : Controller
    {
        private IPublisherData _pubData;

        public PublisherController(IPublisherData _pubData)
        {
            this._pubData = _pubData;
        }

        [HttpPost]
        public IActionResult AddBook(PublisherDTO dto)
        {
            _pubData.AddPublisher(dto);
            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + dto.Name, dto);
        }

        [HttpGet("{publisherName}/publisherbooks")]
        public IActionResult GetBooks(string publisherName)
        {
            var publisher = _pubData.GetBooks(publisherName);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            return NotFound($"The publisher with name {publisher} does not have any books here !");
        }
    }
}
