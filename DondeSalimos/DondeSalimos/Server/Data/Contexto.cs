using DondeSalimos.Shared.Modelos;
using Microsoft.EntityFrameworkCore;

namespace DondeSalimos.Server.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Comercio> Comercio { get; set; }
        public DbSet<Resenia> Resenia { get; set; }
        public DbSet<Publicidad> Publicidad { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Presupuesto> Presupuesto { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<DondeSalimos.Shared.Modelos.Novedad>? Novedad { get; set; }
    }
}
