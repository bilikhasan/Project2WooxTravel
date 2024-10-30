using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()                 //TICK
        {
            return View();
        }
        public ActionResult PartialHead()           //TICK
        {
            return PartialView();
        }
        public ActionResult PartialScript()         //TICK
        {
            return PartialView();
        }
        public ActionResult PartialNavbar()         //TICK
        {
            return PartialView();
        }
        public ActionResult PartialBanner()         //TICK
        {
            var last4Destination = context.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();
            return PartialView(last4Destination);
        }
        public ActionResult PartialCountry(int page = 1)        //TICK
        {
            int pageSize = 3;
            var values = context.Destinations.OrderByDescending(x => x.DestinationId).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((double)context.Destinations.Count() / pageSize);


            return PartialView(values);
        }

        public ActionResult DestinationDetail(int id)           //TICK
        {
            var destination = context.Destinations.Find(id);
            return View(destination);
        }

        














        public ActionResult PartialFooter()
        {
            return PartialView();
        }
    }
}