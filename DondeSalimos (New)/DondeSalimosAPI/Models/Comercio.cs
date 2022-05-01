using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DondeSalimosAPI.Models
{
    public partial class Comercio
    {
        [Key]
        public int Id_Comercio { get; set; }
        public string GeneroMusical { get; set; }
        public int Mesas { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Contrasenia { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Novedades> Novedades { get; set; }
        public virtual ICollection<Publicidad> Publicidad { get; set; }
        public virtual ICollection<Resenia> Resenia { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
