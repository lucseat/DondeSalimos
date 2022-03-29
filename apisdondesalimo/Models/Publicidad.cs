using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Publicidad
    {
        public int idPublicidad { get; set; }
        public Comercio comercio { get; set; }
        public int visualizaciones{ get; set; }
        public int tiempo { get; set; }
        public string? imagenVideo { get; set; }


    }
}
