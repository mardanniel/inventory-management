using InventorySystem.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Data
{
    public class InventoryDbContext : IdentityDbContext<ApplicationUser>
    {
        private ILogger _logger { get; }
        private IConfiguration _appConfig { get; }

        public InventoryDbContext(
            ILogger<InventoryDbContext> logger,
            IConfiguration appConfig)
        {
            this._logger = logger;
            this._appConfig = appConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=InventoryDb;Integrated Security=True;MultipleActiveResultSets=true;";
            
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.InvokeProductSeed();
            builder.InvokeUserSeed();

            base.OnModelCreating(builder);
        }

        public DbSet<Product> Products { get; set; }
    }
}