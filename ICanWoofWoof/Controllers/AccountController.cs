using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ICanWoofWoof.Models;

namespace ICanWoofWoof.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterModel model)
        {
            if(Membership.ValidateUser(model.Login, model.Password))
            {
                
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            Membership.CreateUser(model.Login, model.Password, model.Email);
            return RedirectToAction("Login");
        }

    }
}
