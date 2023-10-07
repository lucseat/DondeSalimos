using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Presupuesto
    {
        [Key]
        public int ID_Presupuesto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public TimeSpan Vigencia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Estado { get; set; }

        public int ID_Factura { get; set; }

        [ForeignKey("ID_Factura")]
        public Factura? Factura { get; set; }
    }
}
