using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebCooking.Data;
using WebCooking.Models;
using WebCooking.Repositories.Implementations;
using WebCooking.Repositories.Interfaces;
using WebCooking.Services.Implementations;
using WebCooking.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 4, 3))));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IRepository<Category>, CategoryRepositoryImpl>();
builder.Services.AddScoped<ICategoryService, CategoryServiceImpl>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}");

app.Run();