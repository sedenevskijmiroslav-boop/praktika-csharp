using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.ShoppingItems.Any())
    {
        db.ShoppingItems.AddRange(
            new ShoppingItem { Name = "Молоко", Quantity = 2, IsBought = false },
            new ShoppingItem { Name = "Хлеб", Quantity = 1, IsBought = false },
            new ShoppingItem { Name = "Яйца", Quantity = 10, IsBought = true },
            new ShoppingItem { Name = "Масло", Quantity = 1, IsBought = false }
        );
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shopping}/{action=Index}/{id?}");

app.Run();