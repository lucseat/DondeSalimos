using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Factura
    {
        [Key]
        public int id_factura { get; set; }
        public Comercio comercio { get; set; }
        public Pago pago { get; set; }
        public string tipoFactura { get; set; }
        public decimal importe { get; set; }
        public DateTime fechaFactura { get; set; }
    }
}
