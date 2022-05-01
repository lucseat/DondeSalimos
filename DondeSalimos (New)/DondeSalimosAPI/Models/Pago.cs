using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public partial class Pago
    {
        [Key]
        public int Id_Pago { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id_Comercio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Estado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Tipo { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
