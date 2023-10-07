using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DondeSalimos.Server.Data;
using DondeSalimos.Shared.Modelos;

namespace DondeSalimos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly Contexto _context;

        public ReservasController(Contexto context)
        {
            _context = context;
        }

        #region // GET: api/reservas
        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> GetReserva()
        {
            if (_context.Reserva == null)
            {
                return NotFound();
            }

            return await _context.Reserva
                                .Include(x => x.Comercio)
                                .Include(x => x.Cliente)
                                .ToListAsync();
        }
        #endregion

        #region // GET: api/reservas/{id}
        [HttpGet("{id:int}", Name = "GetIdReserva")]
        public async Task<ActionResult<Reserva>> GetIdReserva(int id)
        {
            if (_context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.Where(x => x.ID_Reserva == id)
                                                .Include(x => x.Comercio)
                                                .Include(x => x.Cliente)
                                                .FirstOrDefaultAsync();

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }
        #endregion

        #region // GET: api/reservas/{nombreCliente}
        [HttpGet("{nombreCliente}")]
        public async Task<ActionResult<List<Reserva>>> GetNombreCliente(string nombreCliente)
        {
            return await _context.Reserva.Where(x => x.Cliente.Nombre.ToLower().Contains(nombreCliente))
                                        .Include(x => x.Comercio)
                                        .Include(x => x.Cliente)
                                        .ToListAsync();
        }
        #endregion

        #region // PUT: api/reservas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.ID_Reserva)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region // POST: api/reservas
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            if (_context.Reserva == null)
            {
                return Problem("Entity set 'Contexto.Reserva'  is null.");
            }

            try
            {
                _context.Reserva.Add(reserva);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetIdReserva", new { id = reserva.ID_Reserva }, reserva);
        }
        #endregion

        #region // DELETE: api/reservas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            if (_context.Reserva == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            try
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
        #endregion

        private bool ReservaExists(int id)
        {
            return (_context.Reserva?.Any(e => e.ID_Reserva == id)).GetValueOrDefault();
        }
    }
}
