using JobPortal.App.App_Start;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }

}
