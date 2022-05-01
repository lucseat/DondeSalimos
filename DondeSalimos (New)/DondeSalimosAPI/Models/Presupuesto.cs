using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Presupuesto
    {
        [Key]
        public int Id_Presupuesto { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Titulo { get; set; }
        public TimeSpan? Vigencia { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Estado { get; set; }
        public int? Id_Factura { get; set; }

        [ForeignKey("Id_Factura")]
        public virtual Factura Factura { get; set; }
    }
}
