using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICanWoofWoof.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAll()
        {
            return View(new string[] {"value1", "value2"});
        }

        public ActionResult CheckModernizer()
        {
            return View();
        }

        public ActionResult CheckKnockout()
        {
            return View();
        }

    }
}
