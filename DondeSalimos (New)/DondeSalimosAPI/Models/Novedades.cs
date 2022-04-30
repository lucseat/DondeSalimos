using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimosAPI.Models
{
    public partial class Novedades
    {
        [Key]
        public int Id_Novedades { get; set; }
        public int Id_Comercio { get; set; }
        public string Descripcion { get; set; }
        public int Visualizaciones { get; set; }

        [ForeignKey("Id_Comercio")]
        public virtual Comercio IdComercioNavigation { get; set; }
    }
}
