using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Utils;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private IContactData _contactdata;

        public ContactController(IContactData _cotactdata)
        {
            this._contactdata = _cotactdata;
        }

        [HttpGet("{id:int}/getdetails")]
        public IActionResult GetAuthorContact(int id)
        {
            var author = _contactdata.GetAuthorContact(id);

            if (author != null)
            {
                return Ok(author);
            }

            return NotFound($"The file of author with id {id} was not found !");
        }

        [HttpPost]
        public IActionResult AddDetails(AuthorContact contact)
        {
            _contactdata.AddDetails(contact);

            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + contact.Id, contact);
        }
    }
}
