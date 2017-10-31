using Database.DAO;
using Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataEncryption;
using OfficeOpenXml;
using EspireShop.Common;

namespace EspireShop.Areas.Administrator.Controllers
{
    public class NhanVienController : BaseController
    {

        public void SetTypeUser()
        {
            var dao = new PositionDAO();
            ViewBag.TypeUser = new SelectList(dao.ListAll(), "TypeUser", "TypeName");
        }
        public void SetTypeUser(string TypeId)
        {
            var dao = new PositionDAO();
            ViewBag.TypeUser = new SelectList(dao.ListAll(), "TypeUser", "TypeName", TypeId);
        }
        // GET: Administrator/NhanVien
        public ActionResult Index(string type ,string SearchKey, int page = 1, int pageSize = 15)
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            ViewBag.TypeUser = session.UserType;
            switch (type)
            {
                case "SXTT":
                    var model1 = new StaffDAO().ListAllForSortName(page, pageSize);
                    return View(model1);
                case "LTA":
                    var model2 = new StaffDAO().ListAllFilterAdministrator(page, pageSize);
                    return View(model2);
                case "LTQL":
                    var model3 = new StaffDAO().ListAllFilterManager(page, pageSize);
                    return View(model3);
                case "LTNV":
                    var model4 = new StaffDAO().ListAllFilterStaff(page, pageSize);
                    return View(model4);
                case "SNTT":
                    var model5 = new StaffDAO().ListAllBirthDay(page, pageSize);
                    return View(model5);
                default:
                    var model = new StaffDAO().ListAll(SearchKey, page, pageSize);
                    return View(model);
            }
            
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            if (SessionTypeUser())
            {
                SetTypeUser();
                return View();
            }
            else
            {
                SetAlert("Xin lỗi, bạn không có quyền truy cập", "warning");
                return RedirectToAction("Index", "NhanVien");
            }
        }
        [HttpPost]
        public ActionResult ThemMoi(tbl_Staff model)
        {
            if (ModelState.IsValid)
            {
                if (SessionTypeUser())
                {
                    model.Password = Encryption.GetSHA512("espire123");
                    //model.Image = "/Assets/Admin/images/user.jpg";
                    model.Status = true;
                    var result = new StaffDAO().ThemMoi(model);
                    if (result)
                    {
                        //Thêm thành công, chuyển hướng về NhanVien/Index
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    SetAlert("Xin lỗi, bạn không có quyền truy cập", "warning");
                    return RedirectToAction("Index", "NhanVien");
                }

            }
            SetTypeUser(model.TypeUser);
            return View(model);
        }

        [HttpGet]
        public ActionResult CapNhat(string id)
        {
            if (SessionTypeUser())
            {
                try
                {
                    var model = new StaffDAO().getByID(id);
                    SetTypeUser(model.TypeUser);
                    model.Password = "";
                    return View(model);
                }
                catch (Exception)
                {
                    SetAlert("Có lỗi, vui lòng kiểm tra lại", "warning");
                    return RedirectToAction("Index", "NhanVien");
                }
            }
            else
            {
                SetAlert("Xin lỗi, bạn không có quyền truy cập", "warning");
                return RedirectToAction("Index", "NhanVien");
            }

        }

        [HttpPost]
        public ActionResult CapNhat(tbl_Staff model)
        {
            if (ModelState.IsValid)
            {
                if (SessionTypeUser())
                {
                    var result = new StaffDAO().CapNhat(model);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công", "danger");
                    }
                }
                else
                {
                    SetAlert("Xin lỗi, bạn không có quyền truy cập", "warning");
                    return RedirectToAction("Index", "NhanVien");
                }
            }
            SetTypeUser(model.TypeUser);
            return View(model);
        }

        [HttpGet]
        public ActionResult ResetPassword(string userId)
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            if (SessionTypeUser())
            {
                if (userId.ToUpper()!="ADMIN")
                {
                    var result = new StaffDAO().ResetPassword(userId, Encryption.GetSHA512("espire123"));
                    if (result)
                    {
                        SetAlert("Reset mật khẩu cho [" + userId + "] thành công", "success");
                        return RedirectToAction("Index", "NhanVien");
                    }
                    else
                    {
                        SetAlert("Reset mật khẩu cho [" + userId + "] không thành công", "danger");
                        return RedirectToAction("Index", "NhanVien");
                    }
                }
                else
                {
                    SetAlert("Xin lỗi, bạn thể reset mật khẩu Administrator.", "warning");
                    return RedirectToAction("Index", "NhanVien");
                }
            }
            else
            {
                SetAlert("Xin lỗi, bạn không có quyền truy cập.", "warning");
                return RedirectToAction("Index", "NhanVien");
            }
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            var session = Session[Common.CommonConstants.STAFF_SESSION] as StaffLogin;
            ViewBag.UserID = session.UserId;
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(string OldPass, string NewPass, string ReNewPass)
        {
            var session = Session[Common.CommonConstants.STAFF_SESSION] as StaffLogin;
            if (NewPass.Length>=7)
            {
                if (NewPass == ReNewPass)
                {
                    int result = new StaffDAO().ChangePassword(session.UserId, Encryption.GetSHA512(OldPass), Encryption.GetSHA512(NewPass));
                    if (result == -1)
                    {
                        SetAlert("Mật khẩu cũ không đúng", "danger");
                    }
                    else
                    {
                        SetAlert("Thay đổi mật khẩu thành công", "success");
                    }
                }
                else
                {
                    SetAlert("Mật khẩu không trùng khớp", "danger");
                }
            }
            else
            {
                SetAlert("Mật khẩu phải từ 7 ký tự trở lên", "danger");
            }
            ViewBag.UserID = session.UserId;
            return View();
        }

        public JsonResult ChangeStatus(string idUser)
        {
            if (SessionTypeUser())
            {
                if (idUser.ToLower()!= "admin")
                {
                    var result = new StaffDAO().ChangeStatus(idUser);
                    return Json(new
                    {
                        status = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        status = "error"
                    }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                SetAlert("Xin lỗi, bạn không có quyền truy cập", "warning");
                return Json(new
                {

                }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult DeleteStaff(string userId)
        {

            if (SessionTypeUser())
            {
                if (userId.ToUpper()!="ADMIN")
                {
                    var result = new StaffDAO().Delete(userId);
                    return Json(new { status = result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        status = false
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                SetAlert("Xin lỗi, bạn không có quyền truy cập", "warning");
                return Json(new
                {
                    status="NoAccess"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public void ExportToExcel()
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            if (session.UserType.ToUpper() != "CV003")
            {
                var listStaff = new StaffDAO().ExportToExcel();
                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");


                ws.Cells["A1"].Value = "Báo cáo: ";
                ws.Cells["B1"].Value = "Danh sách nhân viên";

                ws.Cells["A2"].Value = "Ngày xuất: ";
                ws.Cells["B2"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

                ws.Cells["A6"].Value = "Mã nhân viên";
                ws.Cells["B6"].Value = "Chức vụ";
                ws.Cells["C6"].Value = "Họ tên";
                ws.Cells["D6"].Value = "Ngày sinh";
                ws.Cells["E6"].Value = "Giới tính";
                ws.Cells["F6"].Value = "Số điện thoại";
                ws.Cells["G6"].Value = "Email";
                ws.Cells["H6"].Value = "Địa chỉ";

                int rowStart = 7;
                foreach (var item in listStaff)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.userId;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.typeName;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.FullName;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.BirthDay.ToString("dd/MM/yyyy");
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.Sex ? "Nam" : "Nữ";
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.PhoneNumber;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.Email;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.Address;
                    rowStart++;
                }
                ws.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }

        }


    }
}