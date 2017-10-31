using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;
namespace Database.DAO
{
    public class AboutDAO
    {
        EspireDbContext db = null;
        public AboutDAO()
        {
            db = new EspireDbContext();
        }

        public tbl_About FindByID()
        {
            return db.tbl_About.Find(1);
        }

        /// <summary>
        /// Cập nhật trang giới thiệu
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public bool Update(tbl_About ab)
        {
            var model = db.tbl_About.Find(ab.ID);
            model.ModifyBy = ab.ModifyBy;
            model.ModifyDate = ab.ModifyDate;
            model.Content = ab.Content;
            db.SaveChanges();
            return true;
        }
    }
}
