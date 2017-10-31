using System.Web.Mvc;
using System.Web.Routing;

namespace EspireShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Trang quan tri",
                url: "_[ADMIN]_",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Areas.Administrator.Controllers" }
            );

            routes.MapRoute(
                name: "Trang chu",
                url: "trang-chu",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "GioiThieu",
                url: "gioi-thieu",
                defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "Tin tuc",
                url: "tin-tuc",
                defaults: new { controller = "TinTuc", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "Tin tuc tim kiem",
                url: "tin-tuc/tim-kiem",
                defaults: new { controller = "TinTuc", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "Tin tuc theo danh mục",
                url: "tin-tuc/{MetaName}-{CategoryNewID}",
                defaults: new { controller = "TinTuc", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "Chi tiet tin tuc",
                url: "chi-tiet-tin-tuc/{metaTitle}-{newId}",
                defaults: new { controller = "TinTuc", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "Lien he",
                url: "lien-he",
                defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EspireShop.Controllers" }
            );
        }
    }
}
