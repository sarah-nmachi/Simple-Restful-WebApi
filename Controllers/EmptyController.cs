using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEmpty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmptyController : ControllerBase
    {
        private readonly EmptyContext _context;

        public EmptyController(EmptyContext context)
        {
            _context = context;
        }

        //GET:  api/empty
        [HttpGet]
        public ActionResult<IEnumerable<Empty>> GetEmpty()
        {
            return _context.Empties;
        }

        // GET:  api/empty/id
        [HttpGet("{id}")]
        public ActionResult<Empty> GetEmptys(int Id)
        {
            var emptyItem = _context.Empties.Find(Id);
            if (emptyItem == null)
            {
                return NotFound();
            }

            return emptyItem;
        }
        
        // POST: api/empty
        [HttpPost]
        public ActionResult<Empty> PostEmpty(Empty empty)
        {
            _context.Empties.Add(empty);
            _context.SaveChanges();

            
             return CreatedAtAction("GetEmptys", new Empty { Id = empty.Id }, empty );
        }

        //PuT: api/empty/id
        [HttpPut("{id}")]
        public ActionResult PutEmpty (int Id, Empty empty)
        {
            if (Id != empty.Id)
            {
                return BadRequest();
            }

            _context.Entry(empty).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
       
        //Delete: api/empty/id
        [HttpDelete("{id}")]
        public ActionResult<Empty> DeleteEmpty(int Id)
        {
            var Emptyy = _context.Empties.Find(Id);
            if (Emptyy == null)
            {
                return NotFound();
            }
            _context.Empties.Remove(Emptyy);
            _context.SaveChanges();

            return Emptyy;
        }
    }
}