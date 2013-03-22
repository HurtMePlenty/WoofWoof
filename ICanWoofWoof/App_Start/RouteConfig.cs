using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ICanWoofWoof
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Modernizer", "Modern", new {controller = "Home", action = "CheckModernizer"}
                );

            routes.MapRoute("Knockout", "Knockout", new { controller = "Home", action = "CheckKnockout" }
                );

            routes.MapRoute("Knockout2", "Knockout2", new { controller = "Home", action = "KnockoutSinglePage" }
                );

            routes.MapRoute("JSBasic", "JSBasic", new { controller = "Home", action = "CheckJSBasics" }
              );


            routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}