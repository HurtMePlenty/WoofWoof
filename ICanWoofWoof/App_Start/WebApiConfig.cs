using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DALTypes;

namespace ICanWoofWoof
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "MailAPI",
                routeTemplate: "api/mailapi/{folder}",
                defaults: new { controller = "MailAPI" }
                );
            
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{folder}",
            //    defaults: new { folder = RouteParameter.Optional  }
            //    );

        }
    }
}
