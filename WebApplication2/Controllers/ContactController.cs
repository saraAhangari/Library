using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.ModelsDTO;
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

        //[HttpGet("{id:int}/getdetails")]
        //public IActionResult GetAuthorContact(int id)
        //{
        //    var author = _contactdata.GetAuthorContact(id);

        //    if (author != null)
        //    {
        //        return Ok(author);
        //    }

        //    return NotFound($"The file of author with id {id} was not found !");
        //}

        //[HttpPatch("{id:int}")]
        //public IActionResult UpdateDetails(AuthorDetailsDTO contact, int id)
        //{
        //    var currentDetails = _contactdata.GetAuthorContact(id);
        //    //if (currentDetails != null)
        //    //{
        //    //    contact.Id = currentDetails.Id;
        //    //    _contactdata.UpdateDetails(contact);
        //    //}
        //    return Ok(contact);
        //}

        [HttpPost]
        public IActionResult AddDetails(int id, AuthorDetailsDTO contact)
        {
            //_contactdata.AddDetails(id , contact);
            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + contact.Address, contact);
        }
    }
}
