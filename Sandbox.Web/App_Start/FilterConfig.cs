using System.Web;
using System.Web.Mvc;

namespace Sandbox.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Disable HandleErrorFilter per http://benfoster.io/blog/aspnet-mvc-custom-error-pages
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
