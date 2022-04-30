using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Administrador
    {
        [Key]
        public int? id_administrador { get; set; }
        public string usuario { get; set; }
        //se cambio contrasenia
        public string contrasenia { get; set; }
        public string permisos { get; set; }
    }
}
