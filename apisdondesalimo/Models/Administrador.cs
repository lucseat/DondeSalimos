using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Administrador
    {
        public int? idAdministrador { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string  permisos { get; set; }
    }
}
