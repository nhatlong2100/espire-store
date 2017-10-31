using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EspireShop.Areas.Administrator.Models;
using Database.DAO;
using EspireShop.Common;
using DataEncryption;
namespace EspireShop.Areas.Administrator.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Administrator/DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(mDangNhap model)
        {
            if (ModelState.IsValid)
            {
                 int result = new StaffDAO().CheckLogin(model.userId, Encryption.GetSHA512(model.password));
                if (result==-2)
                {
                    //User ID không tồn tại
                    ModelState.AddModelError("", "Mã nhân viên không tồn tại!");
                }
                else if (result == -1)
                {
                    //Sai mật khẩu
                    ModelState.AddModelError("", "Sai mật khẩu!");
                }
                else if (result == 0)
                {
                    //Tài khoản bị khóa
                    ModelState.AddModelError("", "Tài khoản bị khóa. Vui lòng liên hệ quản lý!");
                }
                else if (result==1)
                {
                    //Đăng nhập thành công
                    //Lưu session
                    var staff = new StaffDAO().getByID(model.userId);
                    var staffSession = new StaffLogin();
                    staffSession.UserId = staff.UserID;
                    staffSession.UserType = staff.TypeUser;
                    staffSession.FullName = staff.FullName;
                    staffSession.Image = staff.Image;
                    Session.Add(CommonConstants.STAFF_SESSION, staffSession);
                    //Chuyển về trang chủ
                    return RedirectToAction("Index", "TrangChu");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session[CommonConstants.STAFF_SESSION] = null;
            return Redirect("Index");
        }
    }
}