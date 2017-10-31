using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;

namespace Database.DAO
{
    public class ProductCategoryDAO
    {
        EspireDbContext db = null;
        public ProductCategoryDAO()
        {
            db = new EspireDbContext();
        }

        public tbl_ProductCatalog GetById(string CateId)
        {
            return db.tbl_ProductCatalog.Find(CateId);
        }

        /// <summary>
        /// Lấy ra danh sách hãng theo kiểu sản phẩm
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<tbl_ProductCatalog> ListProductCategory(string type)
        {
            var result = db.tbl_ProductCatalog.Where(x => x.ProductTypeID == type);
            return result.ToList();
        }

        /// <summary>
        /// Thêm mới hãng sản phẩm theo kiểu hảng phẩm
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ThemHang(tbl_ProductCatalog model)
        {
            model.CatalogProductID = AutoId();
            db.tbl_ProductCatalog.Add(model);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CapNhat(tbl_ProductCatalog model)
        {
            var result = db.tbl_ProductCatalog.Find(model.CatalogProductID);
            result.CatalogProductName = model.CatalogProductName;
            result.MetaName = model.MetaName;
            result.Image = model.Image;
            db.SaveChanges();
            return true;
        }

        public string AutoId()
        {
            var result = db.tbl_ProductCatalog.OrderByDescending(x => x.CatalogProductID).FirstOrDefault();
            if (result == null)
            {
                return "CPI001";
            }
            else
            {
                //return result.CatalogProductID;
                string id = "CPI";
                int k = Convert.ToInt32(result.CatalogProductID.ToString().Substring(3));
                k++;
                if (k < 10)
                {
                    id += "00";
                }
                else if (k < 100)
                {
                    id += "0";
                }
                id += k.ToString();
                return id;
            }
        }
    }
}
