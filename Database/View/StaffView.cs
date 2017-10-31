using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.View
{
    public class StaffView
    {
        public string userId { set; get; }
        public string typeId { set; get; }
        public string typeName { set; get; }
        public string FullName { set; get; }
        public bool Sex { set; get; }
        public DateTime BirthDay { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public bool Status { set; get; }
    }
}
