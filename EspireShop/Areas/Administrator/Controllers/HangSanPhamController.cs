using Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.EF;

namespace EspireShop.Areas.Administrator.Controllers
{
    public class HangSanPhamController : BaseController
    {
        private void GetTypeProduct()
        {
            var dao = new ProductTypeDAO();
            ViewBag.ListTypeProduct = new SelectList(dao.ListAll(), "ProductTypeID", "ProductTypeName");
        }
        private void GetTypeProduct(string ProductTypeID)
        {
            var dao = new ProductTypeDAO();
            ViewBag.ListTypeProduct = new SelectList(dao.ListAll(), "ProductTypeID", "ProductTypeName", ProductTypeID);
        }
        // GET: Administrator/HangSanPham
        public ActionResult DanhSach()
        {
            ViewBag.Laptop = new ProductCategoryDAO().ListProductCategory("laptop");
            ViewBag.DienThoai = new ProductCategoryDAO().ListProductCategory("dien-thoai");
            return View();
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            if (CheckType2())
            {
                GetTypeProduct();
                return View();
            }
            else
            {
                SetAlert("Bạn không có quyền truy cập.", "error");
                return RedirectToAction("Index", "TrangChu");
            }
        }
        [HttpPost]
        public ActionResult ThemMoi(tbl_ProductCatalog model)
        {
            if (CheckType2())
            {
                if (ModelState.IsValid)
                {
                    model.MetaName = ConvertToUnSign(model.CatalogProductName);
                    var result = new ProductCategoryDAO().ThemHang(model);
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("DanhSach");
                }
                else
                {
                    SetAlert("Thêm không thành công", "danger");
                }
                GetTypeProduct(model.ProductTypeID);
                return View(model);
            }
            else
            {
                SetAlert("Bạn không có quyền truy cập.", "error");
                return RedirectToAction("Index", "TrangChu");
            }
        }

        [HttpGet]
        public ActionResult CapNhat(string CatalogProductID)
        {
            if (CheckType2())
            {
                try
                {
                    var model = new ProductCategoryDAO().GetById(CatalogProductID);
                    GetTypeProduct(model.ProductTypeID);
                    return View(model);
                }
                catch (Exception)
                {
                    return RedirectToAction("DanhSach");
                }
            }
            else
            {
                SetAlert("Bạn không có quyền truy cập.", "error");
                return RedirectToAction("Index", "TrangChu");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(tbl_ProductCatalog model)
        {
            if (CheckType2())
            {
                if (ModelState.IsValid)
                {
                    model.MetaName = ConvertToUnSign(model.CatalogProductName);
                    var result = new ProductCategoryDAO().CapNhat(model);
                    if (result)
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("DanhSach");
                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công.", "danger");
                    }
                }
                GetTypeProduct(model.ProductTypeID);
                return View(model);
            }
            else
            {
                SetAlert("Bạn không có quyền tru cập!", "error");
                return RedirectToAction("TrangChu", "Index");
            }
        }
    }
}