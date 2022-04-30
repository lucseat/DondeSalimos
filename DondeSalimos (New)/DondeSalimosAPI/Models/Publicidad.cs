using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
