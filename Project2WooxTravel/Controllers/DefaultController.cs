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
            var last4Destination = context.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();
            return PartialView(last4Destination);
        }
        public ActionResult PartialCountry(int page = 1)        
        {
            int pageSize = 3;
            var values = context.Destinations.OrderByDescending(x => x.DestinationId).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((double)context.Destinations.Count() / pageSize);


            return PartialView(values);
        }

        public ActionResult DestinationDetail(int id)           
        {
            var destination = context.Destinations.Find(id);
            return View(destination);
        }

        [HttpGet]
        public ActionResult ReservationModal()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ReservationModal (Reservation reservation)
        {
            try
            {
                reservation.CreatedAt = DateTime.Now;
                context.Reservations.Add(reservation);
                context.SaveChanges();

                return Json(new { success = true, message = "Rezervasyon başarılı bir şekilde oluşturuldu :)" });
            }
            catch (Exception ex)
            {
                return Json (new {sucess=false, message="Rezervasyon oluşturulaMADI :("});
            }
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}