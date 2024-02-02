using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SparkleAir.Infa.EFModel.EFModels;

namespace SparkleAir.FrontEnd.Site.Controllers.MealMessages
{
    public class AirMealsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: AirMeals
        public ActionResult Index()
        {
            var airMeals = db.AirMeals.Include(a => a.AirCabin);
            return View(airMeals.ToList());
        }

        // GET: AirMeals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirMeal airMeal = db.AirMeals.Find(id);
            if (airMeal == null)
            {
                return HttpNotFound();
            }
            return View(airMeal);
        }

        // GET: AirMeals/Create
        public ActionResult Create()
        {
            ViewBag.AirCabinId = new SelectList(db.AirCabins, "Id", "CabinClass");
            return View();
        }

        // POST: AirMeals/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AirCabinId,MealContent,Image,ImageBit,Category")] AirMeal airMeal)
        {
            if (ModelState.IsValid)
            {
                db.AirMeals.Add(airMeal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirCabinId = new SelectList(db.AirCabins, "Id", "CabinClass", airMeal.AirCabinId);
            return View(airMeal);
        }

        // GET: AirMeals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirMeal airMeal = db.AirMeals.Find(id);
            if (airMeal == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirCabinId = new SelectList(db.AirCabins, "Id", "CabinClass", airMeal.AirCabinId);
            return View(airMeal);
        }

        // POST: AirMeals/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AirCabinId,MealContent,Image,ImageBit,Category")] AirMeal airMeal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airMeal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirCabinId = new SelectList(db.AirCabins, "Id", "CabinClass", airMeal.AirCabinId);
            return View(airMeal);
        }

        // GET: AirMeals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirMeal airMeal = db.AirMeals.Find(id);
            if (airMeal == null)
            {
                return HttpNotFound();
            }
            return View(airMeal);
        }

        // POST: AirMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirMeal airMeal = db.AirMeals.Find(id);
            db.AirMeals.Remove(airMeal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
