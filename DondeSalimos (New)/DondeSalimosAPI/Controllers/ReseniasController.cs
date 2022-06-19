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
    public class ReseniasController : ControllerBase
    {
        private readonly Context _context;

        public ReseniasController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Resenias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resenia>>> GetResenia()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var resenias = await _context.Resenia
                                        .Include(x => x.Cliente)
                                        .Include(x => x.Comercio)
                                        .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = resenias;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Resenias/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Resenia>> GetResenia(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var resenia = await _context.Resenia
                                        .Where(x => x.Id_Resenia == id)
                                        .Include(x => x.Cliente)
                                        .Include(x => x.Comercio)
                                        .ToListAsync();

                if (resenia == null)
                {
                    oRespuesta.Mensaje = "La reseña no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Reseña encontrada";
                    oRespuesta.Data = resenia;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Resenias/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResenia(int id, Resenia resenia)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != resenia.Id_Resenia)
                {
                    oRespuesta.Mensaje = "Error al actualizar la reseña";
                }
                else
                {
                    _context.Entry(resenia).State = EntityState.Modified;
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

        #region // POST: api/Resenias
        [HttpPost]
        public async Task<ActionResult<Resenia>> PostResenia(Resenia resenia)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Resenia.Add(resenia);
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

        #region // DELETE: api/Resenias/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resenia>> DeleteResenia(int id)
        {
            var resenia = await _context.Resenia.FindAsync(id);

            if (resenia == null)
            {
                return NotFound();
            }

            _context.Resenia.Remove(resenia);
            await _context.SaveChangesAsync();

            return resenia;
        }
        #endregion

        private bool ReseniaExists(int id)
        {
            return _context.Resenia.Any(e => e.Id_Resenia == id);
        }
    }
}