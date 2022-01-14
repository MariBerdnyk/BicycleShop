using BicycleShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace BicycleShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            SelectList types = new SelectList(db.TypeBicycles, "Id", "Name_type");
            ViewBag.TypeBicycles = types;
            var bicycles = db.Bicycles.Include(p => p.Type);
            return View(bicycles.ToList());
        }
        
        [HttpPost]
        public IActionResult Index(string namebike, string price)
        {

            Bicycle bike = new Bicycle() { Name_bicycle = namebike};
            bike.TypeId = Convert.ToInt32(Request.Form["type"]);
            bike.Price_bicycle = Convert.ToDecimal(price, new CultureInfo("en-US"));
            db.Bicycles.Add(bike);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Bicycle b = db.Bicycles.Find(id);
            if (b != null)
            {
                db.Bicycles.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Bicycle b = db.Bicycles.Find(id);
            if (b != null)
            {
                b.Status_bicycle = !b.Status_bicycle;
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
