using SparkleAir.DAL.EFRepository.Airtype_Owns;
using SparkleAir.IDAL.IRepository.Airtype_Owns;
using SparkleAir.BLL.Service.Airtype_Owns;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SparkleAir.Infa.ViewModel.Airtype_Owns;
using SparkleAir.FrontEnd.Site.Models.Authorize;

namespace SparkleAir.FrontEnd.Site.Controllers.Airtype_Owns
{
    [StaffAuthorize(PageName = "Owns")]
    public class OwnsController :BaseController
    {// GET: Properties
        public ActionResult Index()
        {
            //var _repo=new OwnRepository();
            IOwnRepository _repo = new OwnRepository();
            var OwnService = new OwnService(_repo);
            var list = OwnService.GetAll()//dto格式
                .Select(p => new OwnVmIndex
                {
                    Id = p.Id,
                    AirTypeId = p.AirTypeId,
                    FlightModel = p.FlightModel,
                    RegistrationNum = p.RegistrationNum,
                    Status = p.Status,
                    ManufactureYear = p.ManufactureYear,
                })
                .ToList();
            ViewBag.select = list.Select(x => x.Status).Distinct().ToList();//下拉式選單用viewbag
            return View(list);//vm格式
        }

        [HttpPost]
        public ActionResult PartialIndex(string status)
        {
            //var _repo=new OwnRepository();
            IOwnRepository _repo = new OwnRepository();
            var OwnService = new OwnService(_repo);
            var list = OwnService.GetAll()//dto格式
                .Select(p => new OwnVmIndex
                {
                    Id = p.Id,
                    AirTypeId = p.AirTypeId,
                    FlightModel = p.FlightModel,
                    RegistrationNum = p.RegistrationNum,
                    Status = p.Status,
                    ManufactureYear = p.ManufactureYear,
                })
                .OrderBy(s => s.AirTypeId).ToList();


            // 创建一个 OwnVmIndex 模型实例
            List<OwnVmIndex> filteredList;

            if (status == "All")
            {
                // 如果选择 "All"，则返回整个列表
                filteredList = list;
            }
            else
            {
                filteredList = list.Where(x => x.Status == status).ToList();
            }
            // 传递模型给视图
            return PartialView("_PartialIndex", filteredList);
        }


        

        public ActionResult Create()
        { return View(); }

        [HttpPost]
        public ActionResult Create(OwnVm model)

        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                IOwnRepository _repo = new OwnRepository();
                var OwnService = new OwnService(_repo);
                OwnService.CreateOwns(model);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

        }



        public ActionResult Update(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IOwnRepository _repo = new OwnRepository();
            var OwnService = new OwnService(_repo);
            var data = OwnService.Get(id);

            var OwnVm = new OwnVm
            {

                AirTypeId = data.AirTypeId,
                RegistrationNum = data.RegistrationNum,
                Status = data.Status,
                ManufactureYear = data.ManufactureYear,
            };
            //db.Categories.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(OwnVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(OwnVm model)

        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                IOwnRepository _repo = new OwnRepository();
                var OwnService = new OwnService(_repo);
                OwnService.UpdateOwns(model);
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
            IOwnRepository _repo = new OwnRepository();
            var OwnService = new OwnService(_repo);
            var data = OwnService.Get(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            var OwnVmIndex = new OwnVmIndex
            {
                AirTypeId = data.AirTypeId,
                FlightModel = data.FlightModel,
                RegistrationNum = data.RegistrationNum,
                Status = data.Status,
                ManufactureYear = data.ManufactureYear,
            };

            return View(OwnVmIndex);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            IOwnRepository _repo = new OwnRepository();
            var OwnService = new OwnService(_repo);
            //var data=OwnService.Delete(id);
            OwnService.Delete(id);
            return RedirectToAction("Index");
        }




    }
}
