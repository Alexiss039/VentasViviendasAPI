using Microsoft.EntityFrameworkCore;
using VentasViviendasAPI.Models;

namespace VentasViviendasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoVivienda> TiposVivienda { get; set; }
        public DbSet<Vivienda> Viviendas { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vivienda>()
              .HasOne(v => v.TipoVivienda)
              .WithMany(tv => tv.Viviendas)
              .HasForeignKey(v => v.TipoViviendaId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Vivienda)
                .WithOne(v => v.Venta)
                .HasForeignKey<Venta>(v => v.ViviendaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
