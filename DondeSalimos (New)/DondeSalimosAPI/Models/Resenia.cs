using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Resenia
    {
        [Key]
        public int Id_Resenia { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Comercio { get; set; }
        public string Reportado { get; set; }
        public bool? Mostrar { get; set; }
        public string Comentario { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey("Id_Comercio")]
        public virtual Comercio IdComercioNavigation { get; set; }
    }
}
