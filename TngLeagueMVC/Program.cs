using API.Dependency;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TngLeague.Domain;
using TngLeague.Domain.Entities;
using TngLeague.Web.Data;

var builder = WebApplication.CreateBuilder(args);


var assemblyService = Assembly.Load("TngLeague.Application");
//builder.Services.DependencyInjection(builder.Configuration, assemblyService);


//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/Account/Login";
//    options.AccessDeniedPath = "/Account/AccessDenied";
//});

// Add services to the container.



builder.Services.AddControllersWithViews();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var logger = services.GetRequiredService<ILogger<DbInitializer>>();
//    await DbInitializer.SeedDatabase(services, logger);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
