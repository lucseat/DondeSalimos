using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Reserva
    {
        public int idReserva { get; set; }
        public Comercio comercio { get; set; }
        public Clientes cliente { get; set; }
        public int cantPersonas { get; set; }
        public int tolerancia { get; set; }

    }
}
