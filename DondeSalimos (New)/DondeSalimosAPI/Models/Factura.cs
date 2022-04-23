using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Presupuesto = new HashSet<Presupuesto>();
        }

        [Key]
        public int Id_Factura { get; set; }
        public int Id_Comercio { get; set; }
        public int Id_Pago { get; set; }
        public string TipoFactura { get; set; }
        public float Importe { get; set; }
        public byte[] FechaFactura { get; set; }

        [ForeignKey("Id_Comercio")]
        public virtual Comercio IdComercioNavigation { get; set; }
        [ForeignKey("Id_Pago")]
        public virtual Pago IdPagoNavigation { get; set; }
        public virtual ICollection<Presupuesto> Presupuesto { get; set; }
    }
}
