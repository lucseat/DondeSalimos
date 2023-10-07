using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestosController : ControllerBase
    {
        private readonly Contexto _context;

        public PresupuestosController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/presupuestos
        [HttpGet]
        public async Task<ActionResult<List<Presupuesto>>> GetPresupuestos()
        {
            if (_context.Presupuesto == null)
            {
                return NotFound();
            }

            return await _context.Presupuesto
                                    .Include(x => x.Factura)
                                    .ToListAsync();
        }
        #endregion

        #region // GET: api/presupuestos/{id}
        [HttpGet("{id:int}", Name = "GetIdPresupuesto")]
        public async Task<ActionResult<Presupuesto>> GetIdPresupuesto(int id)
        {
            if (_context.Presupuesto == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuesto.Where(x => x.ID_Presupuesto == id)
                                                      .Include(x => x.Factura)
                                                      .FirstOrDefaultAsync();

            if (presupuesto == null)
            {
                return NotFound();
            }

            return presupuesto;
        }
        #endregion

        #region // GET: api/presupuestos/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Presupuesto>>> GetNombreComercio(string nombreComercio)
        {
            return await _context.Presupuesto.Where(x => x.Factura.Comercio.Nombre.ToLower().Contains(nombreComercio))
                                            .Include(x => x.Factura.Comercio)
                                            .ToListAsync();
        }
        #endregion

        #region // PUT: api/presupuestos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresupuesto(int id, Presupuesto presupuesto)
        {
            if (id != presupuesto.ID_Presupuesto)
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
        #endregion

        #region // POST: api/presupuestos
        [HttpPost]
        public async Task<ActionResult<Presupuesto>> PostPresupuesto(Presupuesto presupuesto)
        {
            if (_context.Presupuesto == null)
            {
                return Problem("Entity set 'Contexto.Presupuesto'  is null.");
            }

            try
            {
                _context.Presupuesto.Add(presupuesto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return CreatedAtAction("GetIdPresupuesto", new { id = presupuesto.ID_Presupuesto }, presupuesto);
        }
        #endregion

        #region // DELETE: api/presupuestos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresupuesto(int id)
        {
            if (_context.Presupuesto == null)
            {
                return NotFound();
            }

            var presupuesto = await _context.Presupuesto.FindAsync(id);

            if (presupuesto == null)
            {
                return NotFound();
            }

            try
            {
                _context.Presupuesto.Remove(presupuesto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool PresupuestoExists(int id)
        {
            return (_context.Presupuesto?.Any(e => e.ID_Presupuesto == id)).GetValueOrDefault();
        }
    }
}
