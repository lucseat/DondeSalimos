using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComerciosController : ControllerBase
    {
        private readonly Contexto _context;

        public ComerciosController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/comercios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comercio>>> GetAll()
        {
            if (_context.Comercio == null)
            {
                return NotFound();
            }

            return await _context.Comercio
                                .Include(x => x.Usuario)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/comercios/{id}
        [HttpGet("{id:int}", Name = "GetIdComercio")]
        public async Task<ActionResult<Comercio>> GetIdComercio(int id)
        {
            if (_context.Comercio == null)
            {
                return NotFound();
            }

            //var comercio = await _context.Comercio.FindAsync(id);
            var comercio = await _context.Comercio.Where(x => x.ID_Comercio == id)
                                                    .Include(x => x.Usuario)
                                                    .FirstOrDefaultAsync();

            if (comercio == null)
            {
                return NotFound();
            }

            return comercio;
        }
        #endregion

        #region // GET: api/comercios/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Comercio>>> GetNameComercio(string nombreComercio)
        {
            return await _context.Comercio.Where(x => x.Nombre.ToLower().Contains(nombreComercio))
                                            .Include(x => x.Usuario)
                                            .ToListAsync();
        }
        #endregion

        #region // PUT: api/comercios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComercio(int id, Comercio comercio)
        {
            if (id != comercio.ID_Comercio)
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
        #endregion

        #region // POST: api/comercios
        [HttpPost]
        public async Task<ActionResult<Comercio>> PostComercio(Comercio comercio)
        {
            if (_context.Comercio == null)
            {
                return Problem("Entity set 'Contexto.Comercio'  is null.");
            }

            try
            {
                _context.Comercio.Add(comercio);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdComercio", new { id = comercio.ID_Comercio }, comercio);
        }
        #endregion

        #region // DELETE: api/comercios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComercio(int id)
        {
            if (_context.Comercio == null)
            {
                return NotFound();
            }

            var comercio = await _context.Comercio.FindAsync(id);

            if (comercio == null)
            {
                return NotFound();
            }

            try
            {
                _context.Comercio.Remove(comercio);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool ComercioExists(int id)
        {
            return (_context.Comercio?.Any(e => e.ID_Comercio == id)).GetValueOrDefault();
        }
    }
}
