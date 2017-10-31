using Database.DAO;
using EspireShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace EspireShop.Areas.Administrator.Controllers
{
    public class TrangChuController : BaseController
    {
        [ChildActionOnly]
        public PartialViewResult _Header()
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            ViewBag.Info = new StaffDAO().getByID(session.UserId);
            return PartialView();
        }
        // GET: Administrator/TrangChu
        public ActionResult Index()
        {
            
            return View();
        }
        
    }
}