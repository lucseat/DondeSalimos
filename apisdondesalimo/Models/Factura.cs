using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Factura
    {
        public int idFactura { get; set; }
        public Comercio comercio { get; set; }
        public Pago Pago { get; set; }
        public string tipoFactura { get; set; }
        public decimal importe { get; set; }
        public DateTime fechaFactura { get; set; }


    }
}
