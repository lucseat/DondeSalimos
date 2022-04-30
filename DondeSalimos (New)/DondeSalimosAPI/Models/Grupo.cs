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
        public string NombreGrupo { get; set; }
        public int CantIntegrantes { get; set; }
        public string Enlace_Comunicacion { get; set; }
        public int Localizacion { get; set; }
        public int? Id_Cliente { get; set; }
        public int? Id_Administrador { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey("Id_Administrador")]
        public virtual Administrador IdAdministradorNavigation { get; set; }
    }
}
