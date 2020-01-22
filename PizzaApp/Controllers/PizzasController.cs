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
    public class PizzasController : ControllerBase
    {
        private s16485Context _context;
        public PizzasController(s16485Context context)
        {
            _context = context;
        } 

        //api/pizzaCala
        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.PizzaCala.ToList());
        }

        //api/pizzaCala/4
        [HttpGet("{idGotowaPizza:int}")]
        public IActionResult GetPizza(int idGotowaPizza)
        {
            var pizzaCala = _context.PizzaCala.FirstOrDefault(p => p.IdGotowaPizza == idGotowaPizza);
            if (idGotowaPizza == null)
            {
                return NotFound();
            }

            return Ok(idGotowaPizza);
        }

    }
}