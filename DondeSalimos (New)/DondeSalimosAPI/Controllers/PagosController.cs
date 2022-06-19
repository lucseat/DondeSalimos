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
    public class PagosController : ControllerBase
    {
        private readonly Context _context;

        public PagosController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPago()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var pagos = await _context.Pago
                                    .Include(x => x.Factura)
                                    .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = pagos;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Pagos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetPago(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var pago = await _context.Pago
                                    .Where(x => x.Id_Pago == id)
                                    .Include(x => x.Factura)
                                    .FirstOrDefaultAsync();

                if (pago == null)
                {
                    oRespuesta.Mensaje = "El pago no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Pago encontrado";
                    oRespuesta.Data = pago;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Pagos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, Pago pago)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != pago.Id_Pago)
                {
                    oRespuesta.Mensaje = "Error al actualizar el pago";
                }
                else
                {
                    _context.Entry(pago).State = EntityState.Modified;
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

        #region // POST: api/Pagos
        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(Pago pago)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Pago.Add(pago);
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

        #region // DELETE: api/Pagoes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pago>> DeletePago(int id)
        {
            var pago = await _context.Pago.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            _context.Pago.Remove(pago);
            await _context.SaveChangesAsync();

            return pago;
        }
        #endregion

        private bool PagoExists(int id)
        {
            return _context.Pago.Any(e => e.Id_Pago == id);
        }
    }
}
