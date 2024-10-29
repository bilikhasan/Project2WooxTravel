using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Entities;
using PagedList;


namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        TravelContext context = new TravelContext();

        [Authorize]
        public ActionResult CategoryList(int page = 1)
        {
            // CategoryStatus == true olan kategorileri al ve sıralama ekle
            var values = context.Categories
                .Where(c => c.CategoryStatus == true)
                .OrderBy(c => c.CategoryId); // Sıralama ekleniyor

            // Sayfalama: her sayfada 5 veri olacak şekilde
            int pageSize = 5;
            var pagedCategories = values.ToPagedList(page, pageSize);

            return View(pagedCategories);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            category.CategoryStatus = false;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            value.CategoryStatus = false;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
    }
}