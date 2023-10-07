using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Publicidad
    {
        [Key]
        public int ID_Publicidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Visualizaciones { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public TimeSpan Tiempo { get; set; }

        public bool ImagenVideo { get; set; }

        public int ID_Comercio { get; set; }

        [ForeignKey("ID_Comercio")]
        public Comercio? Comercio { get; set; }
    }
}
