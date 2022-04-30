using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimosAPI.Models;

namespace DondeSalimosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReseniasController : ControllerBase
    {
        private readonly Context _context;

        public ReseniasController(Context context)
        {
            _context = context;
        }

        // GET: api/Resenias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resenia>>> GetResenia()
        {
            return await _context.Resenia.ToListAsync();
        }

        // GET: api/Resenias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resenia>> GetResenia(int id)
        {
            var resenia = await _context.Resenia.FindAsync(id);

            if (resenia == null)
            {
                return NotFound();
            }

            return resenia;
        }

        // PUT: api/Resenias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResenia(int id, Resenia resenia)
        {
            if (id != resenia.Id_Resenia)
            {
                return BadRequest();
            }

            _context.Entry(resenia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReseniaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Resenias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Resenia>> PostResenia(Resenia resenia)
        {
            _context.Resenia.Add(resenia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResenia", new { id = resenia.Id_Resenia }, resenia);
        }

        // DELETE: api/Resenias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resenia>> DeleteResenia(int id)
        {
            var resenia = await _context.Resenia.FindAsync(id);
            if (resenia == null)
            {
                return NotFound();
            }

            _context.Resenia.Remove(resenia);
            await _context.SaveChangesAsync();

            return resenia;
        }

        private bool ReseniaExists(int id)
        {
            return _context.Resenia.Any(e => e.Id_Resenia == id);
        }
    }
}
