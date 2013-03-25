using System.Web;
using System.Web.Mvc;
using ICanWoofWoof.ActionFilters;

namespace ICanWoofWoof
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyCustomActionFilter());
        }
    }
}