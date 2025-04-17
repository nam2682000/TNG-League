using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            try
            {
                var result = _doiDauService.GetAllDoiDau(IdGiaiDau);
                return View(result);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public async Task<IActionResult> ChiTiet(int id)
        {
            try
            {
                var result = await _doiDauService.ChiTietDoiDau(id);
                return View(result);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
        public IActionResult ThemMoi()
        {
            return View();
        }
        public async Task<JsonResult> ThemMoi(DoiDauThanhVienModel model)
        {
            bool check = false;
            try
            {
                check = await _doiDauService.TaoDoiDau(IdGiaiDau, model);
            }
            catch (Exception e)
            {

            }
            return Json(check);
        }
        public async Task<JsonResult> SuaDoiDau(int id, DoiDauThanhVienModel model)
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
