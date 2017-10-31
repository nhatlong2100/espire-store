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
    public class StaffDAO
    {
        EspireDbContext db = null;
        public StaffDAO()
        {
            db = new EspireDbContext();
        }

        public int CheckLogin(string UserID, string Password)
        {
            var result = db.tbl_Staff.SingleOrDefault(x => x.UserID == UserID);
            if (result!=null)
            {
                if (result.Password==Password)
                {
                    if (result.Status==true)
                    {
                        return 1; //Đăng nhập thành công
                    }
                    else
                    {
                        return 0; //Tài khoản vô hiệu hóa
                    }
                }
                else
                {
                    return -1; //Sai mật khẩu
                }
            }
            else
            {
                return -2; //UserID không tồn tại
            }
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>result</returns>
        public tbl_Staff getByID(string userId)
        {
            var result = db.tbl_Staff.SingleOrDefault(x => x.UserID == userId);
            return result;
        }

        /// <summary>
        /// Lấy ra danh sách nhân viên
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>StaffView</returns>
        public IEnumerable<StaffView> ListAll(string key, int page, int pageSize)
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay=staff.BirthDay,
                             PhoneNumber=staff.PhoneNumber,
                             Status=staff.Status
                         };
            if (!string.IsNullOrEmpty(key))
            {
                result = result.Where(x => x.FullName.Contains(key) || x.userId.Contains(key));
            }
            result = result.OrderBy(x => x.typeId);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Lấy ra danh sách nhân viên đã sắp xếp theo tên
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>StaffView</returns>
        public IEnumerable<StaffView> ListAllForSortName(int page, int pageSize)
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay = staff.BirthDay,
                             PhoneNumber = staff.PhoneNumber,
                             Status = staff.Status
                         };
            result = result.OrderBy(x => x.FullName);
            return result.ToPagedList(page, pageSize);
        }

        public IEnumerable<StaffView> ListAllFilterAdministrator(int page, int pageSize)
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay = staff.BirthDay,
                             PhoneNumber = staff.PhoneNumber,
                             Status = staff.Status
                         };
            result = result.Where(x => x.typeId == "CV001");
            result = result.OrderBy(x => x.FullName);
            return result.ToPagedList(page, pageSize);
        }

        public IEnumerable<StaffView> ListAllFilterManager(int page, int pageSize)
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay = staff.BirthDay,
                             PhoneNumber = staff.PhoneNumber,
                             Status = staff.Status
                         };
            result = result.Where(x => x.typeId == "CV002");
            result = result.OrderBy(x => x.FullName);
            return result.ToPagedList(page, pageSize);
        }

        public IEnumerable<StaffView> ListAllFilterStaff(int page, int pageSize)
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay = staff.BirthDay,
                             PhoneNumber = staff.PhoneNumber,
                             Status = staff.Status
                         };
            result = result.Where(x => x.typeId == "CV003");
            result = result.OrderBy(x => x.FullName);
            return result.ToPagedList(page, pageSize);
        }

        public IEnumerable<StaffView> ListAllBirthDay(int page, int pageSize)
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay = staff.BirthDay,
                             PhoneNumber = staff.PhoneNumber,
                             Status = staff.Status
                         };
            result = result.Where(x => x.BirthDay.Month==DateTime.Now.Month);
            result = result.OrderBy(x => x.FullName);
            return result.ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Xuất các thông tin của người dùng ra file excel
        /// </summary>
        /// <returns></returns>
        public List<StaffView> ExportToExcel()
        {
            var result = from staff in db.tbl_Staff
                         join pos in db.tbl_Position
                         on staff.TypeUser equals pos.TypeUser
                         select new StaffView
                         {
                             userId = staff.UserID,
                             typeId = staff.TypeUser,
                             typeName = pos.TypeName,
                             FullName = staff.FullName,
                             Sex = staff.Sex,
                             BirthDay = staff.BirthDay,
                             PhoneNumber = staff.PhoneNumber,
                             Status = staff.Status,
                             Address=staff.Address,
                             Email=staff.Emaill
                         };
            return result.ToList();
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ThemMoi(tbl_Staff model)
        {
            model.UserID = UserIDAuto();
            db.tbl_Staff.Add(model);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CapNhat(tbl_Staff model)
        {
            var result = db.tbl_Staff.Find(model.UserID);
            result.FullName = model.FullName;
            result.Image = model.Image;
            result.Emaill = model.Emaill;
            result.PhoneNumber = model.PhoneNumber;
            result.Sex = model.Sex;
            result.BirthDay = model.BirthDay;
            result.Address = model.Address;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Xóa nhân viên theo User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Delete(string userId)
        {
            var result = db.tbl_Staff.Find(userId);
            db.tbl_Staff.Remove(result);
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ChangePassword(string UserID, string OldPass, string NewPass)
        {
            var result = db.tbl_Staff.Find(UserID);
            if (result.Password!=OldPass)
            {
                return -1; //Mật khẩu hiện tại không đúng
            }
            else
            {
                result.Password = NewPass;
                db.SaveChanges();
                return 1; //Thành công;
                
            }
        }

        public bool ResetPassword(string userId, string EnPassword)
        {
            var result = db.tbl_Staff.Find(userId);
            result.Password = EnPassword;
            db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Thay đổi trạng thái tài khoản
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ChangeStatus(string userId)
        {
            var result = db.tbl_Staff.Find(userId);
            result.Status = !result.Status;
            db.SaveChanges();
            return result.Status;
        }

        /// <summary>
        /// Tự động điền user id
        /// </summary>
        /// <returns></returns>
        public string UserIDAuto()
        {
            string id = "US";
            int k = Convert.ToInt32((from a in db.tbl_Staff where a.UserID != "admin" orderby a.UserID descending select a.UserID).First().Substring(2));
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
