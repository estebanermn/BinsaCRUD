using BinsaCRUD.Models;
using Microsoft.EntityFrameworkCore;


namespace BinsaCRUD.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<ContactoCliente> ContactosCliente => Set<ContactoCliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabla Clientes
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nombre)
                      .IsRequired()
                      .HasMaxLength(40);

                entity.Property(c => c.Domicilio).HasMaxLength(40);
                entity.Property(c => c.CodigoPostal).HasMaxLength(5);
                entity.Property(c => c.Poblacion).HasMaxLength(40);

                // Relación uno-a-muchos con ContactosCliente
                entity.HasMany(c => c.Contactos)
                      .WithOne(cc => cc.Cliente)
                      .HasForeignKey(cc => cc.ClienteId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Tabla ContactosCliente
            modelBuilder.Entity<ContactoCliente>(entity =>
            {
                entity.HasKey(cc => cc.Id);

                entity.Property(cc => cc.Nombre).HasMaxLength(40);
                entity.Property(cc => cc.Telefono).HasMaxLength(40);
                entity.Property(cc => cc.Email).HasMaxLength(40);
            });
        }
    }

}
