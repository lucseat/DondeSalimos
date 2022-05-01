using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Grupo
    {
        [Key]
        public int Id_Grupo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreGrupo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CantIntegrantes { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string EnlaceComunicacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Localizacion { get; set; }
        public int? Id_Cliente { get; set; }
        public int? Id_Administrador { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("Id_Administrador")]
        public virtual Administrador Administrador { get; set; }
    }
}
