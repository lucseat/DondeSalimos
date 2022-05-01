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
    public class PublicidadesController : ControllerBase
    {
        private readonly Context _context;

        public PublicidadesController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Publicidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicidad>>> GetPublicidad()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var publicidades = await _context.Publicidad
                                            .Include(x => x.Id_Comercio)
                                            .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = publicidades;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Publicidades/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicidad>> GetPublicidad(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var publicidad = await _context.Publicidad
                                            .Where(x => x.Id_Publicidad == id)
                                            .Include(x => x.Id_Comercio)
                                            .FirstOrDefaultAsync();

                if (publicidad == null)
                {
                    oRespuesta.Mensaje = "La publicidad no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Publicidad encontrada";
                    oRespuesta.Data = publicidad;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Publicidads/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicidad(int id, Publicidad publicidad)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != publicidad.Id_Publicidad)
                {
                    oRespuesta.Mensaje = "Error al actualizar la publicidad";
                }
                else
                {
                    _context.Entry(publicidad).State = EntityState.Modified;
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

        #region // POST: api/Publicidades
        [HttpPost]
        public async Task<ActionResult<Publicidad>> PostPublicidad(Publicidad publicidad)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Publicidad.Add(publicidad);
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

        #region // DELETE: api/Publicidads/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Publicidad>> DeletePublicidad(int id)
        {
            var publicidad = await _context.Publicidad.FindAsync(id);

            if (publicidad == null)
            {
                return NotFound();
            }

            _context.Publicidad.Remove(publicidad);
            await _context.SaveChangesAsync();

            return publicidad;
        }
        #endregion

        private bool PublicidadExists(int id)
        {
            return _context.Publicidad.Any(e => e.Id_Publicidad == id);
        }
    }
}
