using PagedList;
using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult ReservationList(int page = 1)
        {

            int pageSize = 5;
            var reservations = context.Reservations.OrderBy(x => x.ReservationId).ToPagedList(page, pageSize);

            return View(reservations);
        }
    }
}