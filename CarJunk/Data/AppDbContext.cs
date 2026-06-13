using CarJunk.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CarJunk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AutoReacondicionado> AutosReacondicionados { get; set; }
        public DbSet<AutoPiezas> AutosPiezas { get; set; }
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<VentaPieza> VentasPiezas { get; set; }
        public DbSet<Desperdicio> Desperdicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Herencia: tabla por tipo (TPT)
            modelBuilder.Entity<AutoReacondicionado>().ToTable("AutosReacondicionados");
            modelBuilder.Entity<AutoPiezas>().ToTable("AutosPiezas");

            // Precio con precisión monetaria
            modelBuilder.Entity<AutoReacondicionado>()
                .Property(a => a.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pieza>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<VentaPieza>()
                .Property(v => v.PrecioVenta)
                .HasColumnType("decimal(18,2)");

            // Completitud es calculada, ignorarla en BD
            modelBuilder.Entity<AutoPiezas>()
                .Ignore(a => a.Completitud);
        }
    }
}