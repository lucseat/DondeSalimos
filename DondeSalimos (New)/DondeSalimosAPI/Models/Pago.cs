using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Pago
    {
        public Pago()
        {
            Factura = new HashSet<Factura>();
        }

        [Key]
        public int Id_Pago { get; set; }
        public int Id_Comercio { get; set; }
        public bool Estado { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
