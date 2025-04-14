using Microsoft.AspNetCore.Mvc;

namespace TngLeague.Web.Controllers
{
    public class XepHang : Controller
    {
        public IActionResult Index(int? tabActive = 1)
        {
            ViewBag.tabActive = tabActive;
            return View();
        }
    }
}
