using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovedadesController : ControllerBase
    {
        private readonly Contexto _context;

        public NovedadesController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/novedades
        [HttpGet]
        public async Task<ActionResult<List<Novedad>>> GetNovedades()
        {
            if (_context.Novedad == null)
            {
                return NotFound();
            }

            return await _context.Novedad
                                .Include(x => x.Comercio)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/novedades/{id}
        [HttpGet("{id:int}", Name = "GetIdNovedad")]
        public async Task<ActionResult<Novedad>> GetIdNovedad(int id)
        {
            if (_context.Novedad == null)
            {
                return NotFound();
            }

            var novedades = await _context.Novedad.Where(x => x.ID_Novedad == id)
                                                  .Include(x => x.Comercio)
                                                  .FirstOrDefaultAsync();

            if (novedades == null)
            {
                return NotFound();
            }

            return novedades;
        }
        #endregion

        #region // GET: api/novedades/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Novedad>>> GetNombreComercio(string nombreComercio)
        {
            return await _context.Novedad.Where(x => x.Comercio.Nombre.ToLower().Contains(nombreComercio))
                                        .Include(x => x.Comercio)
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/novedades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNovedades(int id, Novedad novedad)
        {
            if (id != novedad.ID_Novedad)
            {
                return BadRequest();
            }

            _context.Entry(novedad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NovedadExists(id))
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

        #region // POST: api/novedades
        [HttpPost]
        public async Task<ActionResult<Novedad>> PostNovedades(Novedad novedad)
        {
            if (_context.Novedad == null)
            {
                return Problem("Entity set 'Contexto.Novedades'  is null.");
            }

            try
            {
                _context.Novedad.Add(novedad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdNovedad", new { id = novedad.ID_Novedad }, novedad);
        }
        #endregion

        #region // DELETE: api/novedades/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNovedades(int id)
        {
            if (_context.Novedad == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedad.FindAsync(id);

            if (novedad == null)
            {
                return NotFound();
            }

            try
            {
                _context.Novedad.Remove(novedad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool NovedadExists(int id)
        {
            return (_context.Novedad?.Any(e => e.ID_Novedad == id)).GetValueOrDefault();
        }
    }
}
