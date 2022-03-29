using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Presupuesto
    {
        public int idPresupuesto { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime vigencia { get; set; }
        public string estado { get; set; }
        public Factura? factura { get; set; }
     

    }
}
