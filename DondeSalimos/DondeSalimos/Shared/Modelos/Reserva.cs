using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimos.Shared.Modelos
{
    public class Reserva
    {
        [Key]
        public int ID_Reserva { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CantPersonas { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public TimeSpan TiempoTolerancia { get; set; }

        public int ID_Comercio { get; set; }

        public int ID_Cliente { get; set; }

        [ForeignKey("ID_Comercio")]
        public Comercio? Comercio { get; set; }

        [ForeignKey("ID_Cliente")]
        public Cliente? Cliente { get; set; }
    }
}
