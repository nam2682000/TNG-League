using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TngLeague.Domain;
using TngLeagueMVC.Models;

namespace TngLeagueMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        return View();
    }

    [HttpGet]
    public async Task<JsonResult> GetProducts()
    {
        // Giả sử lấy dữ liệu từ một dịch vụ bất đồng bộ
        var products = await Task.FromResult(new[] { "Product1", "Product2", "Product3" });
        return Json(products); // Trả về JSON
    }

    public IActionResult Privacy(ThanhVien thanhVien)
    {
        if (!ModelState.IsValid)
        {
            return View(thanhVien);
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
