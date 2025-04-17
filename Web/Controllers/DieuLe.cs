using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DieuLe : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
