using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
