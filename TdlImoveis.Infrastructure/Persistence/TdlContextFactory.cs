using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace tdlimoveis.Infrastructure.Persistence
{
    public class TdlContextFactory : IDesignTimeDbContextFactory<TdlContext>
    {
        public TdlContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TdlImoveis.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TdlContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new TdlContext(optionsBuilder.Options);
        }
    }
}