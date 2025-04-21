using Application.Extensions;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LichThiDauController : BaseController
    {
        private readonly ITranDauService _tranDauService;

        public LichThiDauController(ITranDauService tranDauService)
        {
            _tranDauService = tranDauService;
        }

        public async Task<IActionResult> Index(int idGiaiDau)
        {
            try{
                SessionHelper.SelectGiaiDau(HttpContext.Session, idGiaiDau.ToString());
                var data = await _tranDauService.GetLichThiDau(idGiaiDau);
                return View(data);
            }
            catch(Exception e){
                return View("Error");
            }
        }
        public async Task<IActionResult> ChiTiet(int idTranDau)
        {
            try{
                var data = await _tranDauService.ChiTietTranDau(idTranDau);
                return View(data);
            }
                catch(Exception e){
                    return View("Error");
            }
        }


        [HttpPost]
        public async Task<JsonResult> ThemTranDau(List<TranDauAddModel> models)
        {
            bool check = false;
            try
            {
                check = await _tranDauService.ThemTranDau(GiaiDauId, models);
            }
            catch (Exception e)
            {
            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> XoaTranDau(int id)
        {
            bool check = false;
            try
            {
                check = await _tranDauService.XoaTranDau(id);
            }
            catch (Exception e)
            {
            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> CapNhatChiTietTranDau(int id, TranDauUpdate model)
        {
            bool check = false;
            try
            {
                check = await _tranDauService.CapNhatChiTietTranDau(id, model);
            }
            catch (Exception e)
            {
            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> ThemSuKien(int idSuKien, ThanhVienSuKienModel model)
        {
            bool check = false;
            try
            {
                check = await _tranDauService.ThemSuKien(idSuKien, model);
            }
            catch (Exception e)
            {
            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> SuaSuKien(int idSuKien, ThanhVienSuKienModel model)
        {
            bool check = false;
            try
            {
                check = await _tranDauService.SuaSuKien(idSuKien, model);
            }
            catch (Exception e)
            {
            }
            return Json(check);
        }

        [HttpPost]
        public async Task<JsonResult> XoaSuKien(bool isGhiBan, bool isThePhat, int id)
        {
            bool check = false;
            try
            {
                check = await _tranDauService.XoaSuKien(isGhiBan, isThePhat, id);
            }
            catch (Exception e)
            {
            }
            return Json(check);
        }
    }
}
