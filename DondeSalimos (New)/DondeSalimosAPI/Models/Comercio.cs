using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DondeSalimosAPI.Models
{
    public partial class Comercio
    {
        public Comercio()
        {
            Factura = new HashSet<Factura>();
            Novedades = new HashSet<Novedades>();
            Publicidad = new HashSet<Publicidad>();
            Resenia = new HashSet<Resenia>();
            Reserva = new HashSet<Reserva>();
        }

        [Key]
        public int Id_Comercio { get; set; }
        public string GeneroMusical { get; set; }
        public int Mesas { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Email { get; set; }
        public int? Telefono { get; set; }
        public string Direccion { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<Novedades> Novedades { get; set; }
        public virtual ICollection<Publicidad> Publicidad { get; set; }
        public virtual ICollection<Resenia> Resenia { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
