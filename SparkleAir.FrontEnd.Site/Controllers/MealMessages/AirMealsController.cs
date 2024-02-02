using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SparkleAir.BLL.Service.MealMessages;
using SparkleAir.DAL.EFRepository.MealMessages;
using SparkleAir.IDAL.IRepository.MealMessages;
using SparkleAir.Infa.Dto.MealMessages;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.MealMessage;

namespace SparkleAir.FrontEnd.Site.Controllers.MealMessages
{
    public class AirMealsController : BaseController
    {
        private readonly AppDbContext db=new AppDbContext();
        private readonly AirMealService _service;
        private readonly IAirMealRepository _repo;

        public AirMealsController()
        {
            _repo = new AirMealEFRepository();
            _service = new AirMealService(_repo);
        }
        // GET: AirMeals
        public ActionResult Index()
        {
            var dtos = _service.Search();
            var vm=dtos.Select(x=>new AirMealVm
            {
                Id = x.Id,
                Name = x.Name,
                AirCabinId = x.AirCabinId,
                MealContent = x.MealContent,
                Image=x.Image,
                Category=x.Category
            }).ToList();
            return View(vm);
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
        public ActionResult Create(AirMealVm vm)
        {
            if (ModelState.IsValid)
            {
                AirMealDto dto = new AirMealDto
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    AirCabinId = vm.AirCabinId,
                    MealContent = vm.MealContent,
                    Image = vm.Image,
                    //ImageBit = vm.ImageBit,
                    Category = vm.Category
                };
                _service.Create(dto);
                return RedirectToAction("Index");
            }

            ViewBag.AirCabinId = new SelectList(db.AirCabins, "Id", "CabinClass", vm.AirCabinId);
            return View(vm);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,AirCabinId,MealContent,Image,ImageBit,Category")] AirMeal airMeal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AirMeals.Add(airMeal);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AirCabinId = new SelectList(db.AirCabins, "Id", "CabinClass", airMeal.AirCabinId);
        //    return View(airMeal);
        //}

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
