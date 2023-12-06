using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Data;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("database")!;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                options => options.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds));
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
