using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimos.Shared.Modelos
{
    public class Comercio
    {
        [Key]
        public int ID_Comercio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        public string GeneroMusical { get; set; }

        public int Mesas { get; set; }

        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NroDocumento { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Email es inválido.")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }

        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public Usuario? Usuario { get; set; }
    }
}
