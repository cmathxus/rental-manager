using Microsoft.EntityFrameworkCore;
using tdlimoveis.Domain.Entities;


namespace tdlimoveis.Infrastructure.Persistence
{
    public class TdlContext : DbContext
    {
        public TdlContext(DbContextOptions<TdlContext> options)
            : base(options)
        {
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>().OwnsOne(o => o.DocumentNumber, dn =>
            {
                dn.Property<string>(d => d.Number)
                    .HasColumnName("DocumentNumber")
                    .HasMaxLength(20)
                    .IsRequired();
            });

            modelBuilder.Entity<Tenant>().OwnsOne(t => t.DocumentNumber, dn =>
            {
                dn.Property<string>(d => d.Number)
                    .HasColumnName("DocumentNumber")
                    .HasMaxLength(20)
                    .IsRequired();
            });
        }
    }
}