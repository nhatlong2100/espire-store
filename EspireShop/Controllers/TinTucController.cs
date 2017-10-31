using Database.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Database.EF;
namespace EspireShop.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        private static string key;
        public ActionResult Index(string CategoryNewID, string KeyWord, int page = 1, int pageSize = 6)
        {
            key = KeyWord;
            ViewBag.KeyWordSearch = key;

            var model = new NewsDAO().DanhSachTinMoi(CategoryNewID, KeyWord, page, pageSize);
            return View(model);
        }

        public ActionResult Detail(string newId)
        {
            try
            {
                var model = new NewsDAO().Detail(newId);
                ViewBag.TinLienQuan = new NewsDAO().TinLienQuan(model.CategoryNewID, 3);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult ListTitleName(string prefix)
        {
            EspireDbContext db = new EspireDbContext();
            var data = (from news in db.tbl_News
                        where news.Title.Contains(prefix)
                        select new
                        {
                            newId = news.NewID,
                            metaTitle = news.MetaTitle,
                            nameTitle = news.Title
                        }).ToList();
            return Json(data);
        }
    }
}