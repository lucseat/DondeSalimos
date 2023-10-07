using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly Contexto _context;

        public FacturasController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/facturas
        [HttpGet]
        public async Task<ActionResult<List<Factura>>> GetFacturas()
        {
            if (_context.Factura == null)
            {
                return NotFound();
            }

            return await _context.Factura
                                .Include(x => x.Comercio)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/facturas/{id}
        [HttpGet("{id:int}", Name = "GetIdFactura")]
        public async Task<ActionResult<Factura>> GetIdFactura(int id)
        {
            if (_context.Factura == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.Where(x => x.ID_Pago == id)
                                              .Include(x => x.Comercio)
                                              .FirstOrDefaultAsync();

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }
        #endregion

        #region // GET: api/facturas/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Factura>>> GetNombreComercio(string nombreComercio)
        {
            return await _context.Factura.Where(x => x.Comercio.Nombre.ToLower().Contains(nombreComercio))
                                        .Include(x => x.Comercio)
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/facturas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.ID_Factura)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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

        #region // POST: api/facturas
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            if (_context.Factura == null)
            {
                return Problem("Entity set 'Contexto.Factura'  is null.");
            }

            try
            {
                _context.Factura.Add(factura);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdFactura", new { id = factura.ID_Factura }, factura);
        }
        #endregion

        #region // DELETE: api/facturas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            if (_context.Factura == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            try
            {
                _context.Factura.Remove(factura);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool FacturaExists(int id)
        {
            return (_context.Factura?.Any(e => e.ID_Factura == id)).GetValueOrDefault();
        }
    }
}
