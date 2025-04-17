﻿using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
