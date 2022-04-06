using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apisdondesalimo.Models
{
    public class Contexto : DbContext
    {
      
    
        public DbSet<Clientes> Clientes { get; set; }
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



        //agregue este dbcontext y este constructor va a recibir
        // un objeto de tipo dbcontext opcion de tu data context y se lo pasa
        //al constructor base options
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}

