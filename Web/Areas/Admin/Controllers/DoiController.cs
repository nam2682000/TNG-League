using Application.Interfaces;
using Application.Models;
using Domain.Enums;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _doiDauService.GetAllDoiDau(GiaiDauId);
                return View(result);
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<JsonResult> TaoDoiDau(DoiDauThanhVienModel model)
        {
            bool check = false;
            try
            {
                check = await _doiDauService.TaoDoiDau(GiaiDauId, model);
            }
            catch (Exception e)
            {

            }
            return Json(check);
        }

        [HttpPost]
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

        [HttpPost]
        public async Task<JsonResult> XoaThanhVien(int id)
        {
            bool check = false;
            try
            {
                check = await _doiDauService.XoaThanhVien(id);
            }
            catch (Exception e)
            {

            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> XoaDoiDau(int id)
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
