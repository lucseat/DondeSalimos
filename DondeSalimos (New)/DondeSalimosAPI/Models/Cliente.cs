using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; }
        public string apodo { get; set; }
        public string nombre { get; set; }
        public string? tipoDocumento { get; set; }
        public string? nroDocumento { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
    }
}
