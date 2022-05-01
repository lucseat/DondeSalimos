using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public partial class Administrador
    {
        [Key]
        public int Id_Administrador { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contrasenia { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Permisos { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
