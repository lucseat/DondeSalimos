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
    public class NovedadesController : ControllerBase
    {
        private readonly Context _context;

        public NovedadesController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Novedades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Novedades>>> GetNovedades()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var novedades = await _context.Novedades
                                        .Include(x => x.Id_Comercio)
                                        .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = novedades;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Novedades/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Novedades>> GetNovedades(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var novedad = await _context.Novedades
                                        .Where(x => x.Id_Novedades == id)
                                        .Include(x => x.Id_Comercio)
                                        .FirstOrDefaultAsync();

                if (novedad == null)
                {
                    oRespuesta.Mensaje = "La novedad no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Novedad encontrada";
                    oRespuesta.Data = novedad;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Novedades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNovedades(int id, Novedades novedades)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != novedades.Id_Novedades)
                {
                    oRespuesta.Mensaje = "Error al actualizar la novedad";
                }
                else
                {
                    _context.Entry(novedades).State = EntityState.Modified;
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

        #region // POST: api/Novedades
        [HttpPost]
        public async Task<ActionResult<Novedades>> PostNovedades(Novedades novedades)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Novedades.Add(novedades);
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

        #region // DELETE: api/Novedades/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Novedades>> DeleteNovedades(int id)
        {
            var novedad = await _context.Novedades.FindAsync(id);

            if (novedad == null)
            {
                return NotFound();
            }

            _context.Novedades.Remove(novedad);
            await _context.SaveChangesAsync();

            return novedad;
        }
        #endregion

        private bool NovedadesExists(int id)
        {
            return _context.Novedades.Any(e => e.Id_Novedades == id);
        }
    }
}
