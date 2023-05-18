using InventorySystem.API.Enums;
using InventorySystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Data
{
    public static class InventorySeed
    {
        public static void AutoMigrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
                {
                    dbContext.Database.Migrate();
                }
            }
        }

        public static void InvokeUserSeed(this ModelBuilder modelBuilder)
        {
            string defaultPassword = "P@ssword123";

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                    FirstName = "David",
                    LastName = "Acosta",
                    DateOfBirth = DateTime.Now,
                    Gender = 'M',
                    UserName = "admindavidacosta@email.com",
                    Email = "admindavidacosta@email.com",
                    NormalizedUserName = "admindavidacosta@email.com".ToUpper(),
                    NormalizedEmail = "admindavidacosta@email.com".ToUpper(),
                    PasswordHash = passwordHasher.HashPassword(null, defaultPassword)
                }
            );
        }

        public static void InvokeProductSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("40e5c79d-5574-42eb-97af-3855bd512827"),
                    Name = "Melon",
                    Description = "This is the product description of Melon!",
                    Status = Status.Active,
                    Price = 10.69,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("6aef3efc-435d-4df1-b8b1-b418b67555a9"),
                    Name = "Avocado",
                    Description = "This is the product description of Avocado!",
                    Status = Status.Active,
                    Price = 20.69,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Id = Guid.Parse("7801d704-39b0-4bc1-8396-155772b5e094"),
                    Name = "Banana",
                    Description = "This is the product description of Banana!",
                    Status = Status.Active,
                    Price = 15.69,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}