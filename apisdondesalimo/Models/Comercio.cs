using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Comercio
    {
        public string idComercio { get; set; }
        public string generoMusical { get; set; }
        //se elimina capacidad
       // public string capacidad { get; set; }
        public string mesas { get; set; }
        public string nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string usuario { get; set; }
        //se cambia el valor de password por contrasena
        public string contrasena { get; set; }

    }
}
