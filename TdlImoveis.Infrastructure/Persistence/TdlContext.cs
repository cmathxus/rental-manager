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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
            
      modelBuilder.Entity<Tenant>()
          .HasOne(t => t.Contract)
          .WithOne(c => c.Tenant)
          .HasForeignKey<Contract>(c => c.TenantId);
 
    }
  }
}