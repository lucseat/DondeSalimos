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
    public class FacturasController : ControllerBase
    {
        private readonly Context _context;

        public FacturasController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFactura()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var facturas = await _context.Factura
                                        .Include(x => x.Id_Pago)
                                        .Include(x => x.Id_Comercio)
                                        .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = facturas;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Facturas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var factura = await _context.Factura
                                        .Where(x => x.Id_Factura == id)
                                        .Include(x => x.Id_Pago)
                                        .Include(x => x.Id_Comercio)
                                        .FirstOrDefaultAsync();

                if (factura == null)
                {
                    oRespuesta.Mensaje = "La factura no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Factura encontrado";
                    oRespuesta.Data = factura;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Facturas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != factura.Id_Factura)
                {
                    oRespuesta.Mensaje = "Error al actualizar la factura";
                }
                else
                {
                    _context.Entry(factura).State = EntityState.Modified;
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

        #region // POST: api/Facturas
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Factura.Add(factura);
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

        #region // DELETE: api/Facturas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> DeleteFactura(int id)
        {
            var factura = await _context.Factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            _context.Factura.Remove(factura);
            await _context.SaveChangesAsync();

            return factura;
        }
        #endregion

        private bool FacturaExists(int id)
        {
            return _context.Factura.Any(e => e.Id_Factura == id);
        }
    }
}
