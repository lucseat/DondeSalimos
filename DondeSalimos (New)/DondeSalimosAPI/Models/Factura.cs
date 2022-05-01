using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Factura
    {
        [Key]
        public int Id_Factura { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id_Comercio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id_Pago { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string TipoFactura { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public float Importe { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaFactura { get; set; }

        [ForeignKey("Id_Comercio")]
        public virtual Comercio Comercio { get; set; }
        [ForeignKey("Id_Pago")]
        public virtual Pago Pago { get; set; }
        public virtual ICollection<Presupuesto> Presupuesto { get; set; }
    }
}
