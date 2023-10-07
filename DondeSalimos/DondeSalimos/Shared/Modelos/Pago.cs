using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Pago
    {
        [Key]
        public int ID_Pago { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Tipo { get; set; }

        public int ID_Comercio { get; set; }

        [ForeignKey("ID_Comercio")]
        public Comercio? Comercio { get; set; }
    }
}
