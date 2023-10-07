using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly Contexto _context;

        public GruposController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/grupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupos()
        {
            if (_context.Grupo == null)
            {
                return NotFound();
            }

            return await _context.Grupo
                                .Include(x => x.Cliente)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/grupos/{id}
        [HttpGet("{id:int}", Name = "GetIdGrupo")]
        public async Task<ActionResult<Grupo>> GetIdGrupo(int id)
        {
            if (_context.Grupo == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo.Where(x => x.ID_Grupo == id)
                                            .Include(x => x.Cliente)
                                            .FirstOrDefaultAsync();

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }
        #endregion

        #region // GET: api/grupos/{nombreGrupo}
        [HttpGet("{nombreGrupo}")]
        public async Task<ActionResult<List<Grupo>>> GetNombreGrupo(string nombreGrupo)
        {
            return await _context.Grupo.Where(x => x.NombreGrupo.ToLower().Contains(nombreGrupo))
                                        .Include(x => x.Cliente)        
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/grupos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupo(int id, Grupo grupo)
        {
            if (id != grupo.ID_Grupo)
            {
                return BadRequest();
            }

            _context.Entry(grupo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoExists(id))
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

        #region // POST: api/grupos
        [HttpPost]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
            if (_context.Grupo == null)
            {
                return Problem("Entity set 'Contexto.Grupo'  is null.");
            }

            try
            {
                _context.Grupo.Add(grupo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdGrupo", new { id = grupo.ID_Grupo }, grupo);
        }
        #endregion

        #region // DELETE: api/grupos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            if (_context.Grupo == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo.FindAsync(id);

            if (grupo == null)
            {
                return NotFound();
            }

            try
            {
                _context.Grupo.Remove(grupo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool GrupoExists(int id)
        {
            return _context.Grupo.Any(x => x.ID_Grupo == id);
        }
    }
}
