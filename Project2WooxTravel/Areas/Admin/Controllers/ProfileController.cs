using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;


namespace Project2WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Admin/Profile
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var username = Session["user"];
            var values = context.Admins.Where(x => x.Username == username).FirstOrDefault();

            return View(values);
        }
    }
}