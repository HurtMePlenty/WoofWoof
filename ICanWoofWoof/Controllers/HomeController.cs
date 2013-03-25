using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using ICanWoofWoof.ActionFilters;

namespace ICanWoofWoof.Controllers
{
    public class HomeController : Controller
    {

        private Cache Cache
        {
            get { return HttpRuntime.Cache; }
        }


        private DateTime CurrentCachedTime
        {
            get
            {
                if (Cache["CurrentCachedTime"] == null)
                {
                    Cache.Add("CurrentCachedTime", DateTime.Now, null, DateTime.Now + new TimeSpan(0, 0, 20),
                              Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                }
                return (DateTime)Cache["CurrentCachedTime"] ;
            }
        }

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

        public ActionResult CheckHelpers()
        {
            return View();
        }

        public ActionResult CheckModernizer()
        {
            return View();
        }

        public ActionResult CheckKnockout()
        {
            return View();
        }


        public ActionResult KnockoutSinglePage()
        {
            return View();
        }

        public ActionResult CheckJSBasics()
        {
            return View();
        }

        public ActionResult TestCache()
        {
            ViewBag.CachedData = CurrentCachedTime; 
            return View();
        }

        #region Filters

        [MyAuthorizeFilter]
        public string CheckAuthorize()
        {
            return "Validation failed";
        }

        [HandleError(View = "Error")]
        public string CheckError()
        {
            throw new NotImplementedException();

        }

        [MyExceptionFilter]
        public string CheckCustomError()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Async

        public async Task<ActionResult> TestAsyncMethods()
        {
            Session["testAsync1"] = "test";
            await AsyncFoo();
            await AsyncFoo2();
            return View();
        }

        private async Task AsyncFoo()
        {
            Session["testAsync2"] = "test";

            Session["testAsync3"] = await Task<string>.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    return "test";
                });


            // Session["testAsync"] = await new WebClient().DownloadStringTaskAsync("http://habrahabr.ru");
            int a = 123;
            Session["testAsync4"] = "test";
        }

        private async Task AsyncFoo2()
        {
            Session["testAsync5"] = "test";

            Session["testAsync6"] = await Task<string>.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    return "test2";
                });


            // Session["testAsync"] = await new WebClient().DownloadStringTaskAsync("http://habrahabr.ru");
            int a = 123;
            Session["testAsync7"] = "test";
        }

        #endregion
    }
}
