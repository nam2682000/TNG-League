using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class Doi : BaseController
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChiTiet(int id)
        {
            return View();
        }
    }
}
