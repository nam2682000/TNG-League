using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LichThiDau : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
