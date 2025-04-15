using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class Doi : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChiTietDoi(int id)
        {
            return View();
        }
    }
}
