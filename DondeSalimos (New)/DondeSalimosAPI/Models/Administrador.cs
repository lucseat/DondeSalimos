using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            Grupo = new HashSet<Grupo>();
        }

        [Key]
        public int Id_Administrador { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Permisos { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}
