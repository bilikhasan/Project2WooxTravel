using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialHead()
        {
            return PartialView();
        }

        public ActionResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult PartialNavbar()
        {
            return PartialView();
        }
        public ActionResult PartialBanner()
        {
            return PartialView();
        }
        public ActionResult PartialCountry()
        {
            return PartialView();
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }
    }
}