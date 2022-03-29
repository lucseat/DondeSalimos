using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Resenia
    {
        public int idResenia { get; set; }
        public Clientes cliente { get; set; }
        public Comercio comercio { get; set; }
        public string reportado { get; set; }
        public string mostrar { get; set; }
        public string comentario { get; set; }

    }
}
