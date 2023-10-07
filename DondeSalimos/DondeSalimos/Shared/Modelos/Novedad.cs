using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Novedad
    {
        [Key]
        public int ID_Novedad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Visualizaciones { get; set; }

        public int ID_Comercio { get; set; }

        [ForeignKey("ID_Comercio")]
        public Comercio? Comercio { get; set; }
    }
}
