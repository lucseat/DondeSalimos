using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReseniasController : ControllerBase
    {
        private readonly Contexto _context;

        public ReseniasController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/resenias
        [HttpGet]
        public async Task<ActionResult<List<Resenia>>> GetResenia()
        {
            if (_context.Resenia == null)
            {
                return NotFound();
            }

            return await _context.Resenia
                                .Include(x => x.Cliente)
                                .Include(x => x.Comercio)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/resenias/{id}
        [HttpGet("{id:int}", Name = "GetIdResenia")]
        public async Task<ActionResult<Resenia>> GetIdResenia(int id)
        {
            if (_context.Resenia == null)
            {
                return NotFound();
            }

            var resenia = await _context.Resenia.Where(x => x.ID_Resenia == id)
                                                .Include(x => x.Cliente)
                                                .Include(x => x.Comercio)
                                                .FirstOrDefaultAsync();

            if (resenia == null)
            {
                return NotFound();
            }

            return resenia;
        }
        #endregion

        #region // GET: api/resenias/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Resenia>>> GetNombreComercio(string nombreComercio)
        {
            return await _context.Resenia.Where(x => x.Comercio.Nombre.ToLower().Contains(nombreComercio))
                                        .Include(x => x.Comercio)
                                        .Include(x => x.Cliente)
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/resenias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResenia(int id, Resenia resenia)
        {
            if (id != resenia.ID_Resenia)
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
        #endregion

        #region // POST: api/resenias
        [HttpPost]
        public async Task<ActionResult<Resenia>> PostResenia(Resenia resenia)
        {
            if (_context.Resenia == null)
            {
                return Problem("Entity set 'Contexto.Resenia'  is null.");
            }

            try
            {
                _context.Resenia.Add(resenia);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdResenia", new { id = resenia.ID_Resenia }, resenia);
        }
        #endregion

        #region // DELETE: api/resenias/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResenia(int id)
        {
            if (_context.Resenia == null)
            {
                return NotFound();
            }

            var resenia = await _context.Resenia.FindAsync(id);

            if (resenia == null)
            {
                return NotFound();
            }

            try
            {
                _context.Resenia.Remove(resenia);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool ReseniaExists(int id)
        {
            return (_context.Resenia?.Any(e => e.ID_Resenia == id)).GetValueOrDefault();
        }
    }
}
