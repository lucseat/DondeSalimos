using Microsoft.EntityFrameworkCore;

namespace DondeSalimosAPI.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Comercio> Comercio { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Novedades> Novedades { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Presupuesto> Presupuesto { get; set; }
        public DbSet<Publicidad> Pubilicidad { get; set; }
        public DbSet<Resenia> Resenia { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NZALAZAR-PC\\SQLEXPRESS; Database=DondeSalimos; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");
            }
        }
    }
}
