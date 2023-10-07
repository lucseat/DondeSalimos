using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly Contexto _context;

        public UsuariosController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/usuarios
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            return await _context.Usuario.ToListAsync();
        }
        #endregion

        #region // GET: api/usuarios/{id}
        [HttpGet("{id:int}", Name = "GetIdUsuario")]
        public async Task<ActionResult<Usuario>> GetIdUsuario(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.ID_Usuario == id).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }
        #endregion

        #region // GET: api/usuarios/{usuario}
        [HttpGet("{usuario}")]
        public async Task<ActionResult<List<Usuario>>> GetUser(string usuario)
        {
            return await _context.Usuario.Where(x => x.NombreUsuario.ToLower().Contains(usuario)).ToListAsync();
        }
        #endregion

        #region // PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            if (id != usuario.ID_Usuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        #region // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Contexto.Usuario'  is null.");
            }

            try
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //_context.Usuario.Add(usuario);
            //await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetIdUsuario", new { id = usuario.ID_Usuario }, usuario);
        }
        #endregion

        #region // DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            try
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.ID_Usuario == id);
        }
    }
}
