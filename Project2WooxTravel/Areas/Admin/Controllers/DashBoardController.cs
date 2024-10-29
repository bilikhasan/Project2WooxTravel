using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {

        TravelContext context = new TravelContext();

        public ActionResult Index()
        {
            var howManyTour = context.Destinations.Select(x => x.DestinationId).Count();
            ViewBag.hmTour = howManyTour;

            var mostExpensiveTour = context.Destinations.Max(x => x.Price);
            ViewBag.meTour = mostExpensiveTour;

            var lowestPrice = context.Destinations.Min(d => d.Price);
            ViewBag.lowestPrice = lowestPrice;

            var maxCapacityTour = context.Destinations.Max(x => x.Capacity);
            ViewBag.maxCapacityTour = maxCapacityTour;

            var maxDayNight = context.Destinations.Max(x => x.DayNight);
            ViewBag.dayNight = maxDayNight;

            var howManyCategory = context.Categories.Select(x => x.CategoryId).Count();
            ViewBag.howManyCategory = howManyCategory;

            var howManyMailSended = context.Messages.Count();
            ViewBag.howManyMailSended = howManyMailSended;

            var avgMoney = Math.Round(context.Destinations.Average(x => x.Price), 2);
            ViewBag.avgMoney = avgMoney;

            var howManyReservation = context.Reservations.Count();
            ViewBag.howManyReservacion = howManyReservation;

            var shortestTour = context.Destinations.Min(x => x.DayNight);
            ViewBag.shortestTour = shortestTour;

            var howManyMessageReceive = context.Messages.Select(x => x.ReceiverMail).Count();
            ViewBag.howManyMeesageReceive = howManyMessageReceive;

            var howManyAdmin = context.Admins.Count();
            ViewBag.howManyAdmin = howManyAdmin;

            return View();
        }
    }
}