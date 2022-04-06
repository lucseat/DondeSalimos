using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Clientes
    {
        public int idCliente { get; set; }
        //se cambio
        public string apodo { get; set; }
        public string nombre { get; set; }
        public string? tipoDocumento { get; set; }
        public int? documento { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string usuario { get; set; }
        //se cambio
        public string contrasena { get; set; }
    

    }
}
