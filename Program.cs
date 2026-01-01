using Microsoft.EntityFrameworkCore;
using OpenTable.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OpenTableContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Area route
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();