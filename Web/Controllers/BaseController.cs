using Application.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected int GiaiDauId => GetGiaiDauId();
        private int GetGiaiDauId()
        {
            var value = SessionHelper.GiaiDauId(HttpContext.Session);
            return int.TryParse(value, out int result) ? result : 0;
        }
    }
}
