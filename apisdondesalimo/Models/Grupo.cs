using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Grupo
    {
        public int idGrupo { get; set; }
        public List<Clientes> clientes { get; set; }
        public List<Clientes> administrador { get; set; }
        //enlace es para la comunicacion en whatsapp o telegram etc
        public string enlaceComunicacion { get; set; }
        public string nombreGrupo { get; set; }
        public int? cantIntegrantes { get; set; }
        public string Localizacion { get; set; }
    }
}
