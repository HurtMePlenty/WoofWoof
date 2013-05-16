using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ActionResult Login(LoginModel model)
        {
            if(Membership.ValidateUser(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
            }
            else
            {
                ViewBag.Error = "User is invalid";
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            Membership.CreateUser(model.Login, model.Password, model.Email);
            return RedirectToAction("Login");
        }

    }
}
