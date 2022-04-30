using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Pago
    {
        [Key]
        public int id_pago { get; set; }
        public Comercio comercio { get; set; }
        public bool estado { get; set; }
        public string tipo { get; set; }
    }
}
