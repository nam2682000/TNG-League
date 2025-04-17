using Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LichThiDauController : BaseController
    {
        public IActionResult Index(int idGiaiDau)
        {
            SessionHelper.SelectGiaiDau(HttpContext.Session, idGiaiDau.ToString());
            return View();
        }
        public IActionResult ChiTiet(int idGiaiDau)
        {
            return View();
        }
    }
}
