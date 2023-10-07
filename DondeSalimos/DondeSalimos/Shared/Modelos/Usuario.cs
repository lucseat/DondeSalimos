using System.ComponentModel.DataAnnotations;

namespace DondeSalimos.Shared.Modelos
{
    public class Usuario
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreUsuario { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contrasenia { get; set; }
        
        public bool Administrador { get; set; }
    }
}
