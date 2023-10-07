using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DondeSalimos.Shared.Modelos
{
    public class Grupo
    {
        [Key]
        public int ID_Grupo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreGrupo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CantIntegrantes { get; set; }

        public string EnlaceComunicacion { get; set; }

        public int Localizacion { get; set; }

        public int ID_Cliente { get; set; }

        [ForeignKey("ID_Cliente")]
        public Cliente? Cliente { get; set; }
    }
}
