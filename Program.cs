using HobbyGarage.Models;
using HobbyGarage.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddSingleton<ICartRepository, CartRepository>();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
