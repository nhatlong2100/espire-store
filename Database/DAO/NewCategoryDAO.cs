using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;
namespace Database.DAO
{
    public class NewCategoryDAO
    {
        EspireDbContext db = null;
        public NewCategoryDAO()
        {
            db = new EspireDbContext();
        }

        public List<tbl_NewCategory> ListAll()
        {
            var result = db.tbl_NewCategory.Where(x => x.ShowOnHome == true);
            return result.ToList();
        }

        public string AutoID()
        {
            string id = "CN";
            int k = Convert.ToInt32((from a in db.tbl_NewCategory  orderby a.CategoryNewID descending select a.CategoryNewID).First().Substring(2));
            k++;
            if (k < 10)
            {
                id += "00";
            }
            else if (k < 100)
            {
                id += "0";
            }
            id = id + k.ToString();
            return id;
        }
    }
}
