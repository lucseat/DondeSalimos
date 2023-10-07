using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly Contexto _context;

        public PagosController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/pagos
        [HttpGet]
        public async Task<ActionResult<List<Pago>>> GetPagos()
        {
            if (_context.Pago == null)
            {
                return NotFound();
            }

            return await _context.Pago
                                .Include(x => x.Comercio)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/pagos/{id}
        [HttpGet("{id:int}", Name = "GetIdPago")]
        public async Task<ActionResult<Pago>> GetIdPago(int id)
        {
            if (_context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago.Where(x => x.ID_Pago == id)
                                          .Include(x => x.Comercio)
                                          .FirstOrDefaultAsync();

            if (pago == null)
            {
                return NotFound();
            }

            return pago;
        }
        #endregion

        #region // GET: api/pagos/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Pago>>> GetNombreComercio(string nombreComercio)
        {
            return await _context.Pago.Where(x => x.Comercio.Nombre.ToLower().Contains(nombreComercio))
                                        .Include(x => x.Comercio)
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/pagos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, Pago pago)
        {
            if (id != pago.ID_Pago)
            {
                return BadRequest();
            }

            _context.Entry(pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(id))
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

        #region // POST: api/pagos
        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(Pago pago)
        {
            if (_context.Pago == null)
            {
                return Problem("Entity set 'Contexto.Pago'  is null.");
            }

            try
            {
                _context.Pago.Add(pago);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdPago", new { id = pago.ID_Pago }, pago);
        }
        #endregion

        #region // DELETE: api/pagos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            if (_context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            try
            {
                _context.Pago.Remove(pago);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool PagoExists(int id)
        {
            return (_context.Pago?.Any(e => e.ID_Pago == id)).GetValueOrDefault();
        }
    }
}
