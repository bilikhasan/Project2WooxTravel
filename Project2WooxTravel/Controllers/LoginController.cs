using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;


namespace Project2WooxTravel.Controllers
{
    public class LoginController : Controller
    {
        
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["user"] = values.Username;
                
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                ViewBag.AlertType = "error";
                ViewBag.AlertMessage = "Kullanıcı adı veya şifre hatalı. Tekrar deneyin.";

                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}