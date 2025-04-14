using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TngLeague.Domain;
using TngLeague.Domain.Entities;

namespace TngLeague.Web.Data;

public class DbInitializer
{
    public static async Task SeedDatabase(IServiceProvider services, ILogger logger)
    {
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            context.Database.Migrate();
            //context.Database.EnsureCreated();
            await SeedAdminAsync(userManager, roleManager);
            await SeedData(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Lỗi khi seed database");
        }
    }

    private static async Task SeedData(AppDbContext context)
    {
        if (context.VaiTros.Any())
        {
            return;
        }
        var vaiTro = new List<VaiTro>
        {
            new VaiTro{TenVaiTro = "Vận động viên"},
            new VaiTro{TenVaiTro = "Huấn luyện viên"},
            new VaiTro{TenVaiTro = "Quản lý"},
        };

        var viTri = new List<ViTri>
        {
            new ViTri{TenViTri = "Tiền đạo"},
            new ViTri{TenViTri = "Tiền vệ"},
            new ViTri{TenViTri = "Hậu vệ"},
            new ViTri{TenViTri = "Thủ môn"},
            new ViTri{TenViTri = "Trọng tài"},
        };

        context.VaiTros.AddRange(vaiTro);
        context.ViTris.AddRange(viTri);
        await context.SaveChangesAsync();
    }
    private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Check if there are any users in the database
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        var admin = await userManager.FindByNameAsync("admin");
        if (admin == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = "admin",
                Email = "nam2682000@gmail.com",
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(newAdmin, "Admin@123");
            await userManager.AddToRoleAsync(newAdmin, "Admin");
        }
    }
}
