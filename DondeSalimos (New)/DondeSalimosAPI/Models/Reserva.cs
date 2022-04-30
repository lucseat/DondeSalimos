using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set; }
        public int cantPersonas { get; set; }
        public DateTime tolerancia { get; set; }
        public Comercio comercio { get; set; }
        public Cliente cliente { get; set; }
    }
}
