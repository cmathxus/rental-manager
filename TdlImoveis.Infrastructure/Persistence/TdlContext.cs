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
  }
}