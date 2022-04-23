using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Publicidad
    {
        [Key]
        public int Id_Publicidad { get; set; }
        public int Id_Comercio { get; set; }
        public int Visualizaciones { get; set; }
        public TimeSpan? Tiempo { get; set; }
        public bool? ImagenVideo { get; set; }

        [ForeignKey("Id_Comercio")]
        public virtual Comercio IdComercioNavigation { get; set; }
    }
}
