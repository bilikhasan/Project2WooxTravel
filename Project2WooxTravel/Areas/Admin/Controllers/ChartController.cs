using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult Line()
        {
            // Benzersiz konu başlıklarını al ve her başlığa karşılık gelen mesaj sayısını hesapla
            var messageSubjects = context.Messages.Select(m => m.Subject).Distinct().ToList();
            var messageCounts = context.Messages
                                        .GroupBy(m => m.Subject)
                                        .Select(g => g.Count()) // Her grubun (konunun) toplam mesaj sayısını al
                                        .ToList();

            // Verilerin dolu olup olmadığını kontrol et
            if (messageSubjects == null || messageSubjects.Count == 0)
            {
                Console.WriteLine("MessageSubjects boş.");
            }
            if (messageCounts == null || messageCounts.Count == 0)
            {
                Console.WriteLine("MessageCounts boş.");
            }

            ViewBag.MessageSubjects = messageSubjects;
            ViewBag.MessageCounts = messageCounts;

            return View();
        }

        public ActionResult Bar()
        {
            // İçinde bulunduğumuz ayı al
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            // İçinde bulunduğumuz ay içerisindeki rezervasyonları al
            var reservations = context.Reservations
                .Where(r => r.ReservationStartDate.Month == currentMonth && r.ReservationStartDate.Year == currentYear)
                .ToList();

            // Günlere göre toplam kişi sayısını hesapla
            var personCounts = new int[DateTime.DaysInMonth(currentYear, currentMonth)];

            foreach (var reservation in reservations)
            {
                var day = reservation.ReservationStartDate.Day;
                personCounts[day - 1] += reservation.PersonCount; // Günler 1'den başladığı için 1 çıkarıyoruz
            }

            ViewBag.PersonCounts = personCounts;
            ViewBag.Days = Enumerable.Range(1, personCounts.Length).ToList(); // 1'den gün sayısına kadar bir liste oluştur
            return View();
        }

        public ActionResult Pie()
        {
            // Destinations tablosundaki başlıkları ve kapasiteleri al
            var destinations = context.Destinations
                .Select(d => new
                {
                    Title = d.Title,
                    Capacity = d.Capacity
                })
                .ToList();

            // Başlıklar ve kapasiteleri ViewBag'de saklayalım
            ViewBag.DestinationTitles = destinations.Select(d => d.Title).ToList();
            ViewBag.DestinationCapacities = destinations.Select(d => d.Capacity).ToList();

            return View();
        }

        public ActionResult Doughnut()
        {
            // Destinations tablosundaki başlıkları ve fiyatları al
            var destinations = context.Destinations
                .Select(d => new
                {
                    Title = d.Title,
                    Price = d.Price
                })
                .ToList();

            // Başlıklar ve fiyatları ViewBag'de saklayalım
            ViewBag.DestinationTitles = destinations.Select(d => d.Title).ToList();
            ViewBag.DestinationPrices = destinations.Select(d => d.Price).ToList();

            return View();
        }
    }
}