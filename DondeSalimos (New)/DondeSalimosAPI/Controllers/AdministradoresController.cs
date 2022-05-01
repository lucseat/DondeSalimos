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
    public class AdministradoresController : ControllerBase
    {
        private readonly Context _context;

        public AdministradoresController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Administradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministrador()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var administradores = await _context.Administrador.ToListAsync();
                oRespuesta.Exito = 1;
                oRespuesta.Data = administradores;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Administradores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var administrador = await _context.Administrador.FindAsync(id);

                if (administrador == null)
                {
                    oRespuesta.Mensaje = "El administrador no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Administrador encontrado";
                    oRespuesta.Data = administrador;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Administradores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != administrador.Id_Administrador)
                {
                    oRespuesta.Mensaje = "Error al actualizar el administrador";
                }
                else
                {
                    _context.Entry(administrador).State = EntityState.Modified;
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

        #region // POST: api/Administradores
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Administrador.Add(administrador);
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

        #region // DELETE: api/Administradores/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Administrador>> DeleteAdministrador(int id)
        {
            var administrador = await _context.Administrador.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();

            return administrador;
        }
        #endregion

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.Id_Administrador == id);
        }
    }
}
