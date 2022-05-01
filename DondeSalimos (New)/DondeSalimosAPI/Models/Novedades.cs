using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Novedades
    {
        [Key]
        public int Id_Novedades { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id_Comercio { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Visualizaciones { get; set; }

        [ForeignKey("Id_Comercio")]
        public virtual Comercio Comercio { get; set; }
    }
}
