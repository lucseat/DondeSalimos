using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Presupuesto
    {
        [Key]
        public int id_presupuesto { get; set; }
        public string titulo { get; set; }
        public DateTime vigencia { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
        public Factura? factura { get; set; }
    }
}
