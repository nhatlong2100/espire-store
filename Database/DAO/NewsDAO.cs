using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;
using PagedList;
using Database.View;

namespace Database.DAO
{
    public class NewsDAO
    {
        EspireDbContext db = null;
        public NewsDAO()
        {
            db = new EspireDbContext();
        }

        /// <summary>
        /// Auto Complete Search
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<string> ListTitleName(string keyword)
        {
            return db.tbl_News.Where(x => x.Title.Contains(keyword)).Select(x=>x.Title).ToList();
        }

        public IEnumerable<NewsView> ListNewByCategory(string cateId,string keyword, int page, int pageSize)
        {
            var result = from news in db.tbl_News
                         join category in db.tbl_NewCategory
                         on news.CategoryNewID equals category.CategoryNewID
                         select new NewsView
                         {
                             NewID = news.NewID,
                             Title = news.Title,
                             Image = news.Image,
                             View = news.View,
                             Status = news.Status,
                             CategoryNewID = news.CategoryNewID,
                             CategoryNewName = category.CategoryNewName
                         };
            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(x => x.Title.Contains(keyword) || x.NewID.Contains(keyword));
            }
            result = result.Where(x => x.CategoryNewID == cateId);
            result = result.OrderBy(x => x.Title);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Lấy danh sách tin tức.
        /// Phân trang.
        /// Tìm kiếm.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<NewsView> ListAll(string search, int page, int pageSize)
        {
            var result = from news in db.tbl_News
                         join category in db.tbl_NewCategory
                         on news.CategoryNewID equals category.CategoryNewID
                         select new NewsView
                         {
                             NewID = news.NewID,
                             Title = news.Title,
                             Image = news.Image,
                             View = news.View,
                             Status = news.Status,
                             CategoryNewID=news.CategoryNewID,
                             CategoryNewName=category.CategoryNewName
                         };
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Title.Contains(search) || x.NewID.Contains(search));
            }
            result = result.OrderBy(x => x.Title);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Danh sách tin thức theo category id
        /// </summary>
        /// <param name="cateId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<NewsView> ListAllByCateID(string cateId, int page, int pageSize)
        {
            var result = from news in db.tbl_News
                         join category in db.tbl_NewCategory
                         on news.CategoryNewID equals category.CategoryNewID
                         select new NewsView
                         {
                             NewID = news.NewID,
                             Title = news.Title,
                             Image = news.Image,
                             View = news.View,
                             Status = news.Status,
                             CategoryNewID = news.CategoryNewID,
                             CategoryNewName = category.CategoryNewName
                         };

            result = result.Where(x => x.CategoryNewID == cateId);
            result = result.OrderBy(x => x.Title);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Danh sách tin tức theo lượt xem
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<NewsView> ListAllByView(int page, int pageSize)
        {
            var result = from news in db.tbl_News
                         join category in db.tbl_NewCategory
                         on news.CategoryNewID equals category.CategoryNewID
                         select new NewsView
                         {
                             NewID = news.NewID,
                             Title = news.Title,
                             Image = news.Image,
                             View = news.View,
                             Status = news.Status,
                             CategoryNewID = news.CategoryNewID,
                             CategoryNewName = category.CategoryNewName
                         };
            //result = result.Where(x => x.CategoryNewID == cateId);
            result = result.OrderByDescending(x => x.View);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Danh sách tin tức bị khóa
        /// </summary>
        /// <param name="cateId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<NewsView> ListAllStatusFalse(int page, int pageSize)
        {
            var result = from news in db.tbl_News
                         join category in db.tbl_NewCategory
                         on news.CategoryNewID equals category.CategoryNewID
                         select new NewsView
                         {
                             NewID = news.NewID,
                             Title = news.Title,
                             Image = news.Image,
                             View = news.View,
                             Status = news.Status,
                             CategoryNewID = news.CategoryNewID,
                             CategoryNewName = category.CategoryNewName
                         };
            result = result.Where(x => x.Status == false);
            result = result.OrderBy(x => x.Title);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Lấy tin tức theo mã tin
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public tbl_News GetByID(string newId)
        {
            return db.tbl_News.Find(newId);
        }

        /// <summary>
        /// Cập nhật tin tức.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CapNhat(tbl_News model)
        {
            var result = db.tbl_News.Find(model.NewID);
            result.Title = model.Title;
            result.MetaTitle = model.MetaTitle;
            result.Image = model.Image;
            result.SummaryText = model.SummaryText;
            result.Content = model.Content;
            result.ModifyBy = model.ModifyBy;
            result.ModifyDate = model.ModifyDate;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Thêm mới tin tức
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNews(tbl_News model)
        {
            model.NewID = AutoIDNew();
            model.View = 0;
            model.Status = true;

            db.tbl_News.Add(model);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Cập nhật trạng thái hiện thị tin tức
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public bool ChangeStatus(string newId)
        {
            var result = db.tbl_News.Find(newId);
            result.Status = !result.Status;
            db.SaveChanges();
            return result.Status;
        }

        /// <summary>
        /// Xóa tin tức
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public bool XoaMauTin(string newId)
        {
            var result = db.tbl_News.Find(newId);
            db.tbl_News.Remove(result);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Lấy danh sách tin
        /// Theo danh mục
        /// Tìm kiếm
        /// Phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<NewsView> DanhSachTinMoi(string cateId, string search, int page, int pageSize)
        {
            var result = from news in db.tbl_News
                         join category in db.tbl_NewCategory
                         on news.CategoryNewID equals category.CategoryNewID
                         select new NewsView
                         {
                             NewID = news.NewID,
                             Title = news.Title,
                             Image = news.Image,
                             NoiDungTomTat = news.SummaryText,
                             Status = news.Status,
                             CategoryNewID = news.CategoryNewID,
                             CategoryNewName = category.CategoryNewName,
                             CreateBy = news.CreateBy,
                             CreateDate = news.CreateDate,
                             metaTitle=news.MetaTitle
                         };
            if (!string.IsNullOrEmpty(search) || !string.IsNullOrEmpty(cateId))
            {
                result = result.Where(x => x.Title.Contains(search) || x.CategoryNewID==cateId);
            }
            result = result.OrderByDescending(x => x.CreateDate);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Chi tiết tin tức
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public tbl_News Detail(string newId)
        {
            return db.tbl_News.Find(newId);
        }

        /// <summary>
        /// Lấy ra danh sách tin tức cùng danh mục (category)
        /// </summary>
        /// <param name="cateId"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<tbl_News> TinLienQuan(string cateId, int take)
        {
            var result = db.tbl_News.Where(x => x.CategoryNewID == cateId).OrderBy(x=>Guid.NewGuid()).Take(take);
            return result.ToList();
        }

        /// <summary>
        /// Tự động điền ID
        /// </summary>
        /// <returns>TTxxxx</returns>
        public string AutoIDNew()
        {

            var result = db.tbl_News.OrderByDescending(x=>x.NewID).FirstOrDefault();
            if (result == null)
            {
                return "TT0001";
            }
            else
            {
                string id = "TT";
                int k = Convert.ToInt32(result.NewID.ToString().Substring(2));
                k++;
                if (k < 10)
                {
                    id += "000";
                }
                else if (k < 100)
                {
                    id += "00";
                }
                else if (k < 1000)
                {
                    id += "0";
                }
                id += k.ToString();
                return id;
            }
        }
    }
}
