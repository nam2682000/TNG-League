using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class XepHang : BaseController
    {
        public IActionResult Index(int? tabActive = 1)
        {
            ViewBag.tabActive = tabActive;
            return View();
        }
    }
}
