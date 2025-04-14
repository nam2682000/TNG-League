using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TngLeague.Web.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            // Kiểm tra đăng nhập (ví dụ: dùng hardcode, có thể thay thế bằng logic kiểm tra DB)
            if (username == "admin" && password == "password")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")  // Gán quyền Admin cho người dùng
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Đăng nhập và tạo cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chính sau khi đăng nhập
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }

        // Đăng xuất
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        // Trang không có quyền truy cập
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
