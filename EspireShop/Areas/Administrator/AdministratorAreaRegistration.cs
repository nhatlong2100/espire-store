using System.Web.Mvc;

namespace EspireShop.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Danh sach hang san pham",
                "Administrator/danh-sach-hang",
                new { controller = "HangSanPham", action = "DanhSach", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "them moi hang san pham",
                "Administrator/them-hang",
                new { controller = "HangSanPham", action = "ThemMoi", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "cap nhat hang san pham",
                "Administrator/cap-nhat-hang-{CatalogProductID}",
                new { controller = "HangSanPham", action = "CapNhat", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Them moi san pham",
                "Administrator/them-moi-san-pham",
                new { controller = "SanPham", action = "ThemSanPham", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller="TrangChu",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}