using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Publicidad
    {
        [Key]
        public int id_publicidad { get; set; }
        public Comercio comercio { get; set; }
        public int visualizaciones { get; set; }
        public DateTime tiempo { get; set; }
        public string? imagenVideo { get; set; }
    }
}
