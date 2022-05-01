using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Reserva
    {
        [Key]
        public int Id_Reserva { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CantPersonas { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public TimeSpan? TiempoTolerancia { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? Id_Comercio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? Id_Cliente { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("Id_Comercio")]
        public virtual Comercio Comercio { get; set; }
    }
}
