﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("{id:int}")]
        public IActionResult UpdateDetails(AuthorDetailsDTO contact, int id)
        {
            _contactdata.UpdateDetails(contact, id);
            return Ok(contact);
        }

    }
}
