using Database.DAO;
using Database.EF;
using EspireShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EspireShop.Areas.Administrator.Controllers
{
    public class GioiThieuController : BaseController
    {
        // GET: Administrator/GioiThieu
        public ActionResult Index()
        {
            var model = new AboutDAO().FindByID();
            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(tbl_About model)
        {
            if (ModelState.IsValid)
            {
                var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
                model.ModifyBy = session.UserId;
                model.ModifyDate = DateTime.Now;
                var result = new AboutDAO().Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thành công.", "success");
                }
                else
                {
                    SetAlert("Có lỗi! Cập nhật không thành công", "danger");
                }
            }
            return View(model);
        }
       
    }
}