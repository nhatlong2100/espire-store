using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EspireShop.Areas.Administrator.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Administrator/SanPham
        public ActionResult ThemSanPham()
        {
            return View();
        }
    }
}