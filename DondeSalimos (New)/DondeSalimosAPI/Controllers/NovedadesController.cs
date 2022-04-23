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
    public class NovedadesController : ControllerBase
    {
        private readonly Context _context;

        public NovedadesController(Context context)
        {
            _context = context;
        }

        // GET: api/Novedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Novedades>>> GetNovedades()
        {
            return await _context.Novedades.ToListAsync();
        }

        // GET: api/Novedades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Novedades>> GetNovedades(int id)
        {
            var novedades = await _context.Novedades.FindAsync(id);

            if (novedades == null)
            {
                return NotFound();
            }

            return novedades;
        }

        // PUT: api/Novedades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNovedades(int id, Novedades novedades)
        {
            if (id != novedades.Id_Novedades)
            {
                return BadRequest();
            }

            _context.Entry(novedades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NovedadesExists(id))
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

        // POST: api/Novedades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Novedades>> PostNovedades(Novedades novedades)
        {
            _context.Novedades.Add(novedades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNovedades", new { id = novedades.Id_Novedades }, novedades);
        }

        // DELETE: api/Novedades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Novedades>> DeleteNovedades(int id)
        {
            var novedades = await _context.Novedades.FindAsync(id);
            if (novedades == null)
            {
                return NotFound();
            }

            _context.Novedades.Remove(novedades);
            await _context.SaveChangesAsync();

            return novedades;
        }

        private bool NovedadesExists(int id)
        {
            return _context.Novedades.Any(e => e.Id_Novedades == id);
        }
    }
}
