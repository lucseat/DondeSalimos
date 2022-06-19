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
    public class PresupuestosController : ControllerBase
    {
        private readonly Context _context;

        public PresupuestosController(Context context)
        {
            _context = context;
        }

        #region // GET: api/Presupuestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presupuesto>>> GetPresupuesto()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var presupuestos = await _context.Presupuesto
                                            .Include(x => x.Factura)
                                            .ToListAsync();

                oRespuesta.Exito = 1;
                oRespuesta.Data = presupuestos;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // GET: api/Presupuestos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Presupuesto>> GetPresupuesto(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                var presupuesto = await _context.Presupuesto
                                            .Where(x => x.Id_Presupuesto == id)
                                            .Include(x => x.Factura)
                                            .FirstOrDefaultAsync();

                if (presupuesto == null)
                {
                    oRespuesta.Mensaje = "El presupuesto no existe";
                }
                else
                {
                    oRespuesta.Exito = 1;
                    oRespuesta.Mensaje = "Presupuesto encontrado";
                    oRespuesta.Data = presupuesto;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }
        #endregion

        #region // PUT: api/Presupuestos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresupuesto(int id, Presupuesto presupuesto)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                if (id != presupuesto.Id_Presupuesto)
                {
                    oRespuesta.Mensaje = "Error al actualizar el presupuesto";
                }
                else
                {
                    _context.Entry(presupuesto).State = EntityState.Modified;
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

        #region // POST: api/Presupuestos
        [HttpPost]
        public async Task<ActionResult<Presupuesto>> PostPresupuesto(Presupuesto presupuesto)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                _context.Presupuesto.Add(presupuesto);
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

        #region // DELETE: api/Presupuestos/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Presupuesto>> DeletePresupuesto(int id)
        {
            var presupuesto = await _context.Presupuesto.FindAsync(id);

            if (presupuesto == null)
            {
                return NotFound();
            }

            _context.Presupuesto.Remove(presupuesto);
            await _context.SaveChangesAsync();

            return presupuesto;
        }
        #endregion

        private bool PresupuestoExists(int id)
        {
            return _context.Presupuesto.Any(e => e.Id_Presupuesto == id);
        }
    }
}
