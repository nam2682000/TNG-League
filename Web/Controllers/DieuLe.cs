using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DieuLe : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
