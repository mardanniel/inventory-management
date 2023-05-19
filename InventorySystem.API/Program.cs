using System.Text.Json.Serialization;
using InventorySystem.API.Data;
using InventorySystem.API.Models;
using InventorySystem.API.Repositories;
using InventorySystem.API.Repositories.Products;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(x => 
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<InventoryDbContext>();

// builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductRepository, ProductSPRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<InventoryDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AutoMigrate();

app.UseAuthorization();

app.MapControllers();

app.Run();
