using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DondeSalimosAPI.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comercio> Comercio { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Novedades> Novedades { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Presupuesto> Presupuesto { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Resenia> Resenia { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
    }
}
