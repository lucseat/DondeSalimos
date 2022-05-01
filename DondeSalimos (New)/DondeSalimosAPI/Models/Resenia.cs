using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Resenia
    {
        [Key]
        public int Id_Resenia { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id_Cliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id_Comercio { get; set; }
        [StringLength(50)]
        public string Reportado { get; set; }
        public bool? Mostrar { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(200)]
        public string Comentario { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("Id_Comercio")]
        public virtual Comercio Comercio { get; set; }
    }
}
