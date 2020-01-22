using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return Ok(pizzaCala);
        }

        [HttpPost]
        public IActionResult Create( PizzaCala newPizzaCala)
        {
            _context.PizzaCala.Add(newPizzaCala);
            _context.SaveChanges();

            return StatusCode(201, newPizzaCala);
        }

        [HttpPut]
        public IActionResult Update(PizzaCala updatedPizzaCala)
        {
      
            if (_context.PizzaCala.Count(p => p.IdGotowaPizza == updatedPizzaCala.IdGotowaPizza) == 0)
            {
                return NotFound();
            }

            _context.PizzaCala.Attach(updatedPizzaCala);
            _context.Entry(updatedPizzaCala).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizzaCala);

        }
        
        [HttpDelete("{idGotowaPizza:int}")]
        public IActionResult Delete(int idPizzaCala)
        {
            var pizza = _context.PizzaCala.FirstOrDefault(p => p.IdGotowaPizza == idPizzaCala);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.PizzaCala.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }


    }
}