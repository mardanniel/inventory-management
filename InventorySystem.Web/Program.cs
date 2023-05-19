using InventorySystem.Web.Repositories;
using InventorySystem.Web.Repositories.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IProductRepository, ProductApiRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
