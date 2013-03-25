using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ICanWoofWoof.ActionFilters
{
    public class MyExceptionFilter: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is System.Exception) //always true
            {
                var server = filterContext.HttpContext.Server;
                server.TransferRequest("~/Error/Index");
            }
        }
    }
}