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
    public class PublicidadesController : ControllerBase
    {
        private readonly Context _context;

        public PublicidadesController(Context context)
        {
            _context = context;
        }

        // GET: api/Publicidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicidad>>> GetPublicidad()
        {
            return await _context.Publicidad.ToListAsync();
        }

        // GET: api/Publicidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicidad>> GetPublicidad(int id)
        {
            var publicidad = await _context.Publicidad.FindAsync(id);

            if (publicidad == null)
            {
                return NotFound();
            }

            return publicidad;
        }

        // PUT: api/Publicidads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicidad(int id, Publicidad publicidad)
        {
            if (id != publicidad.Id_Publicidad)
            {
                return BadRequest();
            }

            _context.Entry(publicidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicidadExists(id))
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

        // POST: api/Publicidads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Publicidad>> PostPublicidad(Publicidad publicidad)
        {
            _context.Publicidad.Add(publicidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicidad", new { id = publicidad.Id_Publicidad }, publicidad);
        }

        // DELETE: api/Publicidads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publicidad>> DeletePublicidad(int id)
        {
            var publicidad = await _context.Publicidad.FindAsync(id);
            if (publicidad == null)
            {
                return NotFound();
            }

            _context.Publicidad.Remove(publicidad);
            await _context.SaveChangesAsync();

            return publicidad;
        }

        private bool PublicidadExists(int id)
        {
            return _context.Publicidad.Any(e => e.Id_Publicidad == id);
        }
    }
}
