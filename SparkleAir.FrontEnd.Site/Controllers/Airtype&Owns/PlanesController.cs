using SparkleAir.BLL.Service.Airtype_Owns;
using SparkleAir.DAL.EFRepository.Airtype_Owns;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Airtype_Owns;
using SparkleAir.Infa.ViewModel.Airtype_Owns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Airtype_Owns
{
    [StaffAuthorize(PageName = "Planes")]
    public class PlanesController : BaseController
    {
        // GET: Planes
        public ActionResult Index()
        {
            //var _repo=new PlaneRepository();
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            var list = planeService.GetAll()//dto格式
                .Select(p => new PlaneVmIndex
                {
                    Id = p.ID,
                    FlightModel = p.FlightModel,
                    ManufactureCompany = p.ManufactureCompany,
                })
                .ToList();

            return View(list);//vm格式
        }

        public ActionResult Details(int id)
        {
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            var data = planeService.Get(id);
            var dataVm = new PlaneVm
            {
                FlightModel = data.FlightModel,
                TotalSeat = data.TotalSeat,
                MaxMile = data.MaxMile,
                MaxWeight = data.MaxWeight,
                ManufactureCompany = data.ManufactureCompany,
                Introduction = data.Introduction,
                Img = data.Img,
                // 其他屬性
            };

            return View(dataVm);//vm格式

        }


        public ActionResult Create()
        { return View(); }

        [HttpPost]
        public ActionResult Create(PlaneVm model)

        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                IPlaneRepository _repo = new PlaneRepository();
                var planeService = new PlaneService(_repo);
                planeService.CreateTypes(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
         

        public ActionResult Update(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            var data = planeService.Get(id);

            var planeVm = new PlaneVm
            {
                FlightModel = data.FlightModel,
                TotalSeat = data.TotalSeat,
                MaxMile = data.MaxMile,
                MaxWeight = data.MaxWeight,
                ManufactureCompany = data.ManufactureCompany,
                Introduction = data.Introduction,
                Img = data.Img,
            };
            //db.Categories.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(planeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(PlaneVm model)

        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                IPlaneRepository _repo = new PlaneRepository();
                var planeService = new PlaneService(_repo);
                planeService.UpdateTypes(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }


        public ActionResult Delete(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            var data = planeService.Get(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var planeVm = new PlaneVm
            {
                FlightModel = data.FlightModel,
                TotalSeat = data.TotalSeat,
                MaxMile = data.MaxMile,
                MaxWeight = data.MaxWeight,
                ManufactureCompany = data.ManufactureCompany,
                Introduction = data.Introduction,
                Img = data.Img,
            };

            return View(planeVm);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            IPlaneRepository _repo = new PlaneRepository();
            var planeService = new PlaneService(_repo);
            //var data=planeService.Delete(id);
            planeService.Delete(id);
            return RedirectToAction("Index");
        }




    }
}
