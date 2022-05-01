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
    public class ReservasController : ControllerBase
    {
        private readonly Context _context;

        public ReservasController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var reservas = await _context.Reserva
                                        .Include(x => x.Id_Cliente)
                                        .Include(x => x.Id_Comercio)
                                        .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = reservas;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Reservas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var reserva = await _context.Reserva
                                        .Where(x => x.Id_Reserva == id)
                                        .Include(x => x.Id_Cliente)
                                        .Include(x => x.Id_Comercio)
                                        .ToListAsync();

                if (reserva == null)
                {
                    oRespuesta.Mensaje = "La reserva no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Reserva encontrada";
                    oRespuesta.Data = reserva;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Reservas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != reserva.Id_Reserva)
                {
                    oRespuesta.Mensaje = "Error al actualizar la reserva";
                }
                else
                {
                    _context.Entry(reserva).State = EntityState.Modified;
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

        #region // POST: api/Reservas
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Reserva.Add(reserva);
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

        #region // DELETE: api/Reservas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }
        #endregion

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id_Reserva == id);
        }
    }
}
