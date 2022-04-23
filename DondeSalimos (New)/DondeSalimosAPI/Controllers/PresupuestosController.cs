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
    public class PresupuestosController : ControllerBase
    {
        private readonly Context _context;

        public PresupuestosController(Context context)
        {
            _context = context;
        }

        // GET: api/Presupuestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presupuesto>>> GetPresupuesto()
        {
            return await _context.Presupuesto.ToListAsync();
        }

        // GET: api/Presupuestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Presupuesto>> GetPresupuesto(int id)
        {
            var presupuesto = await _context.Presupuesto.FindAsync(id);

            if (presupuesto == null)
            {
                return NotFound();
            }

            return presupuesto;
        }

        // PUT: api/Presupuestoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresupuesto(int id, Presupuesto presupuesto)
        {
            if (id != presupuesto.Id_Presupuesto)
            {
                return BadRequest();
            }

            _context.Entry(presupuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresupuestoExists(id))
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

        // POST: api/Presupuestoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Presupuesto>> PostPresupuesto(Presupuesto presupuesto)
        {
            _context.Presupuesto.Add(presupuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresupuesto", new { id = presupuesto.Id_Presupuesto }, presupuesto);
        }

        // DELETE: api/Presupuestoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Presupuesto>> DeletePresupuesto(int id)
        {
            var presupuesto = await _context.Presupuesto.FindAsync(id);
            if (presupuesto == null)
            {
                return NotFound();
            }

            _context.Presupuesto.Remove(presupuesto);
            await _context.SaveChangesAsync();

            return presupuesto;
        }

        private bool PresupuestoExists(int id)
        {
            return _context.Presupuesto.Any(e => e.Id_Presupuesto == id);
        }
    }
}
