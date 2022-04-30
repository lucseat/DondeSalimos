using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Resenia
    {
        [Key]
        public int id_resenia { get; set; }
        public Cliente cliente { get; set; }
        public Comercio comercio { get; set; }
        public string reportado { get; set; }
        public bool mostrar { get; set; }
        public string comentario { get; set; }
    }
}
