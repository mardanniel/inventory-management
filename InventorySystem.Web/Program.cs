using InventorySystem.Web.Repositories;
using InventorySystem.Web.Repositories.Accounts;
using InventorySystem.Web.Repositories.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// builder.Services.AddDistributedMemoryCache();
// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromSeconds(1800);
//     options.Cookie.HttpOnly = true;
//     options.Cookie.IsEssential = true;
// });

builder.Services.AddHttpClient();
builder.Services.AddScoped<IProductRepository, ProductApiRepository>();
builder.Services.AddScoped<IAccountRepository, AccountApiRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
