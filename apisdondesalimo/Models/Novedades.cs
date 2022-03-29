using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Novedades
    {
        public int idNovedad { get; set; }
        public Comercio comercio { get; set; }
        public string descripcion { get; set; }
        public int visualizaciones { get; set; }

    }
}
