using System.Web;
using System.Web.Mvc;

namespace EspireShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //QuG6o24gcXV54buBbiB0aHXhu5ljIHbhu4EgSOG7kyBOaOG6rXQgTG9uZw==
            filters.Add(new HandleErrorAttribute());
        }
    }
}
