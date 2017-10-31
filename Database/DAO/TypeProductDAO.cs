using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;
namespace Database.DAO
{
    public class TypeProductDAO
    {
        EspireDbContext db = null;
        public TypeProductDAO()
        {
            db = new EspireDbContext();
        }

        /// <summary>
        /// Danh sách type product
        /// </summary>
        /// <returns></returns>
        public List<tbl_TypeProduct> ListAllTypeProduct()
        {
            return db.tbl_TypeProduct.ToList();
        }
    }
}
