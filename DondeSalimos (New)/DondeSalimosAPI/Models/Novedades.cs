using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public class Novedades
    {
        [Key]
        public int id_novedad { get; set; }
        public Comercio comercio { get; set; }
        public string descripcion { get; set; }
        public int visualizaciones { get; set; }
    }
}
