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
    public class SkladnikiController : ControllerBase
    {

        private s16485Context _context;
        public SkladnikiController(s16485Context context)
        {
            _context = context;
        }

        //api/skladnik
        [HttpGet]
        public IActionResult GetSkladnik()
        {
            return Ok(_context.Skladnik.ToList());
        }

        //api/skladnik/2
        [HttpGet("{idSkladnik:int}")]
        public IActionResult GetSkladnik(int idSkladnik)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == idSkladnik);
            if (skladnik == null)
            {
                return NotFound();
            }

            return Ok(skladnik);
        }

    }
}