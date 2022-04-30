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
    public class ComerciosController : ControllerBase
    {
        private readonly Context _context;

        public ComerciosController(Context context)
        {
            _context = context;
        }

        // GET: api/Comercios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comercio>>> GetComercio()
        {
            return await _context.Comercio.ToListAsync();
        }

        // GET: api/Comercios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comercio>> GetComercio(int id)
        {
            var comercio = await _context.Comercio.FindAsync(id);

            if (comercio == null)
            {
                return NotFound();
            }

            return comercio;
        }

        // PUT: api/Comercios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComercio(int id, Comercio comercio)
        {
            if (id != comercio.Id_Comercio)
            {
                return BadRequest();
            }

            _context.Entry(comercio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComercioExists(id))
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

        // POST: api/Comercios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comercio>> PostComercio(Comercio comercio)
        {
            _context.Comercio.Add(comercio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComercio", new { id = comercio.Id_Comercio }, comercio);
        }

        // DELETE: api/Comercios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comercio>> DeleteComercio(int id)
        {
            var comercio = await _context.Comercio.FindAsync(id);
            if (comercio == null)
            {
                return NotFound();
            }

            _context.Comercio.Remove(comercio);
            await _context.SaveChangesAsync();

            return comercio;
        }

        private bool ComercioExists(int id)
        {
            return _context.Comercio.Any(e => e.Id_Comercio == id);
        }
    }
}
