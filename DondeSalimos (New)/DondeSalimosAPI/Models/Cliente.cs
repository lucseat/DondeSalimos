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
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }

        public virtual ICollection<Grupo> Grupo { get; set; }
        public virtual ICollection<Resenia> Resenia { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
