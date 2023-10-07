using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicidadesController : ControllerBase
    {
        private readonly Contexto _context;

        public PublicidadesController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/publicidades
        [HttpGet]
        public async Task<ActionResult<List<Publicidad>>> GetPublicidad()
        {
            if (_context.Publicidad == null)
            {
                return NotFound();
            }

            return await _context.Publicidad
                                .Include(x => x.Comercio)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/publicidades/{id}
        [HttpGet("{id:int}", Name = "GetIdPublicidad")]
        public async Task<ActionResult<Publicidad>> GetIdPublicidad(int id)
        {
            if (_context.Publicidad == null)
            {
                return NotFound();
            }

            var publicidad = await _context.Publicidad.Where(x => x.ID_Publicidad == id)
                                                  .Include(x => x.Comercio)
                                                  .FirstOrDefaultAsync();

            if (publicidad == null)
            {
                return NotFound();
            }

            return publicidad;
        }
        #endregion

        #region // GET: api/publicidades/{nombreComercio}
        [HttpGet("{nombreComercio}")]
        public async Task<ActionResult<List<Publicidad>>> GetNombreComercio(string nombreComercio)
        {
            return await _context.Publicidad.Where(x => x.Comercio.Nombre.ToLower().Contains(nombreComercio))
                                        .Include(x => x.Comercio)
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/publicidades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicidad(int id, Publicidad publicidad)
        {
            if (id != publicidad.ID_Publicidad)
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
        #endregion

        #region // POST: api/publicidades
        [HttpPost]
        public async Task<ActionResult<Publicidad>> PostPublicidad(Publicidad publicidad)
        {
            if (_context.Publicidad == null)
            {
                return Problem("Entity set 'Contexto.Publicidad'  is null.");
            }

            try
            {
                _context.Publicidad.Add(publicidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }            

            return CreatedAtAction("GetIdPublicidad", new { id = publicidad.ID_Publicidad }, publicidad);
        }
        #endregion

        #region // DELETE: api/publicidades/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicidad(int id)
        {
            if (_context.Publicidad == null)
            {
                return NotFound();
            }

            var publicidad = await _context.Publicidad.FindAsync(id);

            if (publicidad == null)
            {
                return NotFound();
            }

            try
            {
                _context.Publicidad.Remove(publicidad);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool PublicidadExists(int id)
        {
            return (_context.Publicidad?.Any(e => e.ID_Publicidad == id)).GetValueOrDefault();
        }
    }
}
