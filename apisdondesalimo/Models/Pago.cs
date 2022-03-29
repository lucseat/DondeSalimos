using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Pago
    {
        public int idPago { get; set; }
        public Comercio comercio { get; set; }
        public string estado { get; set; }
        public string tipo { get; set; }

    }
}
