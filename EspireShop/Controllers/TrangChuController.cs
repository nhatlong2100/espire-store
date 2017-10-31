using Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EspireShop.Controllers
{
    public class TrangChuController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult _Navigation()
        {
            ViewBag.NewCategory = new NewCategoryDAO().ListAll();
            ViewBag.TypeProduct = new ProductTypeDAO().ListAll();
            return PartialView();
        }
        // GET: TrangChu
        public ActionResult Index()
        {
            return View();
        }
    }
}