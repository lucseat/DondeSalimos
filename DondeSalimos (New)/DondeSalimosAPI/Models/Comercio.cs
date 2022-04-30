using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Comercio
    {
        [Key]
        public int id_comercio { get; set; }
        public string generoMusical { get; set; }
        public int mesas { get; set; }
        public string nombre { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
    }
}
