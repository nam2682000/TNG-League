using Application.Interfaces;
using Application.Models.DoiDau;
using Application.Models.GiaiDau;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoiController : BaseController
    {
        private readonly IDoiDauService _doiDauService;

        public DoiController(IDoiDauService doiDauService)
        {
            _doiDauService = doiDauService;
        }

        public IActionResult Index(int idGiaiDau)
        {
            return View();
        }
        public IActionResult ChiTiet(int id)
        {
            return View();
        }
        public IActionResult ThemMoi()
        {
            return View();
        }
        public async Task<JsonResult> SuaDoi(int id, DoiDauModel model)
        {
            bool check = false;
            try
            {
                check = await _doiDauService.SuaDoiDau(id, model);
            }
            catch (Exception e)
            {

            }
            return Json(check);
        }
        public async Task<JsonResult> XoaDoi(int id)
        {
            bool check = false;
            try
            {
                check = await _doiDauService.XoaDoiDau(id);
            }
            catch (Exception e)
            {

            }
            return Json(check);
        }
    }
}
