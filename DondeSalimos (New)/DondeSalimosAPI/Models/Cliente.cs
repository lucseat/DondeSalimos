using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public partial class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Apodo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NroDocumento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public int? Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contrasenia { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<Resenia> Resenia { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
