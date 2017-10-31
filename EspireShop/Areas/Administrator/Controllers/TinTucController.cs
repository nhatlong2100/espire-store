using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.DAO;
using Database.EF;

namespace EspireShop.Areas.Administrator.Controllers
{
    public class TinTucController : BaseController
    {
        public void LoadCategory()
        {
            var dao = new NewCategoryDAO();
            ViewBag.ListCategory = new SelectList(dao.ListAll(), "CategoryNewID", "CategoryNewName");
        }
        public void LoadCategory(string id)
        {
            var dao = new NewCategoryDAO();
            ViewBag.ListCategory = new SelectList(dao.ListAll(), "CategoryNewID", "CategoryNewName",id);
        }
        // GET: Administrator/TinTuc
        public ActionResult Index(string filter,string SearchKey, int page=1, int pageSize=12)
        {
            ViewBag.ListCategory = new NewCategoryDAO().ListAll();

            switch (filter)
            {
                case "CN001":
                    var model1 = new NewsDAO().ListAllByCateID("CN001", page, pageSize);
                    return View(model1);
                case "CN002":
                    var model2 = new NewsDAO().ListAllByCateID("CN002", page, pageSize);
                    return View(model2);
                case "CN003":
                    var model3 = new NewsDAO().ListAllByCateID("CN003", page, pageSize);
                    return View(model3);
                case "LuotXem":
                    var model4 = new NewsDAO().ListAllByView( page, pageSize);
                    return View(model4);
                case "BaiVietBiKhoa":
                    var model5 = new NewsDAO().ListAllStatusFalse(page, pageSize);
                    return View(model5);
                default:
                    var model = new NewsDAO().ListAll(SearchKey, page, pageSize);
                    return View(model);
            }
        }

        [HttpGet]
        public ActionResult DangTin()
        {
            LoadCategory();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult DangTin(tbl_News model)
        {
            if (ModelState.IsValid)
            {
                model.MetaTitle = ConvertToUnSign(model.Title);
                model.CreateBy = GetSessionID();
                model.CreateDate = DateTime.Now;
                var result = new NewsDAO().AddNews(model);
                if (result)
                {
                    SetAlert("Đăng tin tức thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Lỗi! Đăng tin tức không thành công", "danger");
                }
            }
            LoadCategory(model.CategoryNewID);
            return View(model);
        }

        [HttpGet]
        public ActionResult CapNhat(string newid)
        {
            try
            {
                LoadCategory(new NewsDAO().GetByID(newid).CategoryNewID);
                var model = new NewsDAO().GetByID(newid);
                return View(model);
            }
            catch (Exception)
            {
                SetAlert("Lỗi! Vui lòng kiểm tra lại.", "warning");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(tbl_News model)
        {
            if (ModelState.IsValid)
            {
                model.MetaTitle = ConvertToUnSign(model.Title);
                model.ModifyBy = GetSessionID();
                model.ModifyDate = DateTime.Now;
                var result = new NewsDAO().CapNhat(model);
                if (result)
                {
                    //Cập nhật thành công,
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Cập nhật không thành công, vui lòng kiểm tra lại!", "danger");
                    return View(model);
                }
            }
            LoadCategory(model.CategoryNewID);
            return View(model);
        }

        public JsonResult XoaTin(string newId)
        {
            var result = new NewsDAO().XoaMauTin(newId);
            return Json(new
            {
                 status=result
            },JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(string newId)
        {
            var result = new NewsDAO().ChangeStatus(newId);
            return Json(new { status=result},JsonRequestBehavior.AllowGet);
        }
    }
}