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

    public IActionResult Index(ThanhVien thanhVien)
    {
        if (!ModelState.IsValid)
        {
            return View(thanhVien);
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
