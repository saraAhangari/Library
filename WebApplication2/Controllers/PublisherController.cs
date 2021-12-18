using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : Controller
    {
        private IPublisherData _publisherdata;

        public PublisherController(IPublisherData _publisherdata)
        {
            this._publisherdata = _publisherdata;
        }
        [HttpGet("allpublishers")]
        public IActionResult GetPublishers()
        {
            return Ok(_publisherdata.GetPublishers());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPublisher(int id)
        {
            var publisher = _publisherdata.GetPublisher(id);

            if (publisher != null)
            {
                return Ok(publisher);
            }

            return NotFound($"The publisher with id {id} was not found !");
        }

        [HttpGet("getpublisherbooks")]
        public IActionResult GetPublisherBooks(Publisher publisher)
        {
            var books = _publisherdata.GetPublisherBooks(publisher);

            if (books != null)
            {
                return Ok(books);
            }

            return NotFound($"The piblisher with id: {publisher.Id} does not have many books !");
        }
    }
}
