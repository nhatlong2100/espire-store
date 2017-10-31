using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.View
{
    public class NewsView
    {
        public string NewID { set; get; }
        public string metaTitle { set; get; }
        public string Title { set; get; }
        public string Image { set; get; }
        public int View { set; get; }
        public bool Status { set; get; }
        public string NoiDungTomTat { set; get; }
        public string NoiDung { set; get; }
        public DateTime CreateDate { set; get; }
        public string CreateBy { set; get; }

        public string CategoryNewID { set; get; }
        public string CategoryNewName { set; get; }
    }
}
