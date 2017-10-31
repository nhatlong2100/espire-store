using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.EF;
namespace Database.DAO
{
    public class PositionDAO
    {
        EspireDbContext db = null;
        public PositionDAO()
        {
            db = new EspireDbContext();
        }

        public List<tbl_Position> ListAll()
        {
            return db.tbl_Position.Where(x=>x.Show==true).ToList();
        }
    }
}
