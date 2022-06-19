using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimosAPI.Models;
using DondeSalimosAPI.Models.Response;

namespace DondeSalimosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly Context _context;

        public GruposController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Grupos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupo()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var grupos = await _context.Grupo
                                        .Include(x => x.Cliente)
                                        .Include(x => x.Administrador)
                                        .ToListAsync();
                oRespuesta.Exito = 1;
                oRespuesta.Data = grupos;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Grupos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetGrupo(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var grupo = await _context.Grupo
                                        .Where(x => x.Id_Grupo == id)
                                        .Include(x => x.Cliente)
                                        .Include(x => x.Administrador)
                                        .FirstOrDefaultAsync();

                if (grupo == null)
                {
                    oRespuesta.Mensaje = "El grupo no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Grupo encontrado";
                    oRespuesta.Data = grupo;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Grupos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupo(int id, Grupo grupo)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != grupo.Id_Grupo)
                {
                    oRespuesta.Mensaje = "Error al actualizar el grupo";
                }
                else
                {
                    _context.Entry(grupo).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // POST: api/Grupos
        [HttpPost]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Grupo.Add(grupo);
                await _context.SaveChangesAsync();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // DELETE: api/Grupoes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grupo>> DeleteGrupo(int id)
        {
            var grupo = await _context.Grupo.FindAsync(id);

            if (grupo == null)
            {
                return NotFound();
            }

            _context.Grupo.Remove(grupo);
            await _context.SaveChangesAsync();

            return grupo;
        }
        #endregion

        private bool GrupoExists(int id)
        {
            return _context.Grupo.Any(e => e.Id_Grupo == id);
        }
    }
}
