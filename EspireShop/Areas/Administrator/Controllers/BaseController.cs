using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EspireShop.Common;
using System.Web.Routing;
using System.Text.RegularExpressions;

namespace EspireShop.Areas.Administrator.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (StaffLogin)Session[CommonConstants.STAFF_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "DangNhap",
                    action = "Index",
                    Area = "Administrator"
                }));
            }
            base.OnActionExecuting(filterContext);
        }
        public void SetAlert(string message, string type)
        {
            TempData["message"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "danger")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        public bool SessionTypeUser()
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            if (session.UserType.ToUpper()=="CV001")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckType2()
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            if (session.UserType.ToUpper() == "CV001" || session.UserType.ToUpper() == "CV002")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetSessionID()
        {
            var session = (StaffLogin)Session[Common.CommonConstants.STAFF_SESSION];
            return session.UserId;
        }

        public string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}