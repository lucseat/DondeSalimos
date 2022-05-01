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
    public class ComerciosController : ControllerBase
    {
        private readonly Context _context;

        public ComerciosController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Comercios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comercio>>> GetComercio()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var comercios = await _context.Comercio.ToListAsync();
                oRespuesta.Exito = 1;
                oRespuesta.Data = comercios;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Comercios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Comercio>> GetComercio(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var comercio = await _context.Comercio.FindAsync(id);

                if (comercio == null)
                {
                    oRespuesta.Mensaje = "El comercio no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Comercio encontrado";
                    oRespuesta.Data = comercio;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Comercios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComercio(int id, Comercio comercio)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != comercio.Id_Comercio)
                {
                    oRespuesta.Mensaje = "Error al actualizar el comercio";
                }
                else
                {
                    _context.Entry(comercio).State = EntityState.Modified;
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

        #region // POST: api/Comercios{id}
        [HttpPost]
        public async Task<ActionResult<Comercio>> PostComercio(Comercio comercio)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Comercio.Add(comercio);
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

        #region // DELETE: api/Comercios/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comercio>> DeleteComercio(int id)
        {
            var comercio = await _context.Comercio.FindAsync(id);

            if (comercio == null)
            {
                return NotFound();
            }

            _context.Comercio.Remove(comercio);
            await _context.SaveChangesAsync();

            return comercio;
        }
        #endregion

        private bool ComercioExists(int id)
        {
            return _context.Comercio.Any(e => e.Id_Comercio == id);
        }
    }
}
