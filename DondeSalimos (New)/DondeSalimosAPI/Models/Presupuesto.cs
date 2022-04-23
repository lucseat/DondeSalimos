using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Presupuesto
    {
        [Key]
        public int Id_Presupuesto { get; set; }
        public string Titulo { get; set; }
        public TimeSpan? Vigencia { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int? Id_Factura { get; set; }

        [ForeignKey("Id_Factura")]
        public virtual Factura IdFacturaNavigation { get; set; }
    }
}
