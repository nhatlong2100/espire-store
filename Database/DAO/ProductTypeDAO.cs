using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;
namespace Database.DAO
{
    public class ProductTypeDAO
    {
        EspireDbContext db = null;
        public ProductTypeDAO()
        {
            db = new EspireDbContext();
        }
        public List<tbl_TypeProduct> ListAll()
        {
            return db.tbl_TypeProduct.ToList();
        }
    }
}
