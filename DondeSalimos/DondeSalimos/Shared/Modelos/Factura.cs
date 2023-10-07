using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Factura
    {
        [Key]
        public int ID_Factura { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string TipoFactura { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double Importe { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaFactura { get; set; }

        public int ID_Comercio { get; set; }

        public int ID_Pago { get; set; }

        [ForeignKey("ID_Comercio")]
        public Comercio? Comercio { get; set; }

        [ForeignKey("ID_Pago")]
        public Pago? Pago { get; set; }
    }
}
