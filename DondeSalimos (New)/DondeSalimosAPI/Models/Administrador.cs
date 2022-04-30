using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public partial class Administrador
    {
        [Key]
        public int Id_Administrador { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Permisos { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
