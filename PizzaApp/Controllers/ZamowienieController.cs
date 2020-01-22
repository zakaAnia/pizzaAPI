using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamowienieController : ControllerBase
    {

        private s16485Context _context;
        public ZamowienieController(s16485Context context)
        {
            _context = context;
        }

        //api/zamowienie
        [HttpGet]
        public IActionResult GetZamowienia()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        //api/zamowienie/1
        [HttpGet("{idZamowienie:int}")]
        public IActionResult GetZamowienie(int idZamowienie)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == idZamowienie);
            if (zamowienie == null)
            {
                return NotFound();
            }

            return Ok(zamowienie);
        }
    }
}