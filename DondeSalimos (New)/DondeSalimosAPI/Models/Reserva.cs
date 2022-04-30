using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Reserva
    {
        [Key]
        public int Id_Reserva { get; set; }
        public int CantPersonas { get; set; }
        public TimeSpan? TiempoTolerancia { get; set; }
        public int? Id_Comercio { get; set; }
        public int? Id_Cliente { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey("Id_Comercio")]
        public virtual Comercio IdComercioNavigation { get; set; }
    }
}
