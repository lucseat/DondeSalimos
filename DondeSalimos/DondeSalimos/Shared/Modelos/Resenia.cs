using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Resenia
    {
        [Key]
        public int ID_Resenia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Reportado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Mostrar { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Comentario { get; set; }

        public int ID_Comercio { get; set; }

        public int ID_Cliente { get; set; }

        [ForeignKey("ID_Comercio")]
        public Comercio? Comercio { get; set; }

        [ForeignKey("ID_Cliente")]
        public Cliente? Cliente { get; set; }
    }
}
