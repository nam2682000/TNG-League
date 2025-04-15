using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities;

namespace Web.Data;

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
        var vaiTros = new List<VaiTro>
        {
            new VaiTro{TenVaiTro = "Vận động viên"},
            new VaiTro{TenVaiTro = "Huấn luyện viên"},
            new VaiTro{TenVaiTro = "Quản lý"},
        };

        var viTris = new List<ViTri>
        {
            new ViTri{TenViTri = "Tiền đạo"},
            new ViTri{TenViTri = "Tiền vệ"},
            new ViTri{TenViTri = "Hậu vệ"},
            new ViTri{TenViTri = "Thủ môn"},
            new ViTri{TenViTri = "Trọng tài"},
        };

        var vongDaus = new List<VongDau>
        {
            new VongDau{TenVongDau = "Tứ kết", SoDoi = 8},
            new VongDau{TenVongDau = "Bán kết", SoDoi = 4 },
            new VongDau{TenVongDau = "Chung kết", SoDoi = 2},
        };

        var hinhThucThiDaus = new List<HinhThucThiDau>
        {
            new HinhThucThiDau { TenHinhThuc = "Vòng tròn", Mota = "Mỗi đội thi đấu với tất cả các đội còn lại. Có thể là 1 lượt (lượt đi) hoặc 2 lượt (lượt đi & lượt về). Tính điểm: Thắng 3, hòa 1, thua 0."},
            new HinhThucThiDau { TenHinhThuc = "Loại trực tiếp", Mota = "Đội thua bị loại ngay."},
            new HinhThucThiDau { TenHinhThuc = "Chia bảng", Mota = "Chia thành nhiều bảng (vòng tròn tính điểm). Chọn đội nhất/nhì bảng vào vòng loại trực tiếp"}
        };

        context.HinhThucThiDaus.AddRange(hinhThucThiDaus);
        context.VongDaus.AddRange(vongDaus);
        context.VaiTros.AddRange(vaiTros);
        context.ViTris.AddRange(viTris);
        await context.SaveChangesAsync();
    }
    private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        const string adminRole = "Admin";
        const string adminUserName = "admin";
        const string adminEmail = "nam2682000@gmail.com";
        const string adminPassword = "Admin@123";
        // 1. Tạo role Admin nếu chưa có
        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }
        // 2. Tạo user admin nếu chưa có
        var admin = await userManager.FindByNameAsync(adminUserName);
        if (admin == null)
        {
            var newAdmin = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(newAdmin, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newAdmin, adminRole);
            }
            else
            {
                throw new Exception("Tạo user admin thất bại: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
