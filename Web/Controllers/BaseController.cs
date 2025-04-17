using Application.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected int? IdGiaiDau => GetIdGiaiDau();
        private int? GetIdGiaiDau()
        {
            var value = SessionHelper.GetIdGiaiDau(HttpContext.Session);
            return int.TryParse(value, out int result) ? result : null;
        }
    }
}
