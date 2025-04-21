using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GiaiDauController : BaseController
    {
        private readonly IGiaiDauService _giaiDauService;

        public GiaiDauController(IGiaiDauService giaiDauService)
        {
            _giaiDauService = giaiDauService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChiTiet(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ThemGiaiDau(GiaiDauModel model)
        {
            bool check = false;
            try{
                check = await _giaiDauService.TaoGiaiDau(model);
            }
            catch(Exception e){

            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> SuaGiaiDau(int id, GiaiDauModel model)
        {
            bool check = false;
            try{
                check = await _giaiDauService.SuaGiaiDau(id, model);
            }
            catch(Exception e){

            }
            return Json(check);
        }
    }
}
