using SparkleAir.BLL.Service.Airports;
using SparkleAir.DAL.EFRepository.Airports;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Airport;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Utility;
using SparkleAir.Infa.Utility.Helper.Airports;
using SparkleAir.Infa.ViewModel.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Airports
{

    [StaffAuthorize(PageName = "Airports")]
    public  class AirportsController : BaseController
    {//
        ////以下是server統一都可以直接叫用的方法
        //public AirportsController()
        //{

        //    _service = new AirportService(efRepository);

        //}
        //private AirportService _service;



        //EF
        IAirportRepository efRepository = new AirportEFRepository(); //也可以改成AirportEFRepository efRepository = new AirportEFRepository();

        // GET: Airports
        public ActionResult Index()
        {
            List<AirportIndexVm> data = GetAll();
            return View(data);
        }


        private List<AirportIndexVm> GetAll()
        {
            var service = new AirportService(efRepository); //告訴service要用接收哪個資料庫

            List<AirportDto> dto = service.GetAll();

            List<AirportIndexVm> vm = dto.Select(p => new AirportIndexVm
            {
                Id = p.Id,
                Lata = p.Lata,
                Gps = p.Gps,
                Country = p.Country,
                City = p.City,
                AirPortName = p.AirPortName,
                TimeArea = p.TimeArea,
                Zone = p.Zone,
                CityIntroduction = p.CityIntroduction,
                Img = p.Img,
                Continent = p.Continent,

            }).ToList();

            return vm;
        }

        #region Delete
        public ActionResult Delete(int id)
        {
            
                DeleteAirport(id);
                return RedirectToAction("Index");
           
        }   
        private void DeleteAirport(int id)
        {
            var service = new AirportService(efRepository); //告訴service要用接收哪個資料庫
            service.Delete(id);
        }
        #endregion  

        #region Create
        public ActionResult Create()
        {
            var service = new AirportService(efRepository);
            ViewBag.editAirport = service.GetAll(); //回傳所有的資料

            return View();
        }

        [HttpPost]
        public ActionResult Create(AirportCreateVm airport, HttpPostedFileBase file1)
        {
            if (!ModelState.IsValid) return View();
            //
            string path = Server.MapPath("~/Files/Airports");
            try
            {
                string newFileName = new UploadFileHelper().UploadImageFile(file1, path);
                airport.Img = newFileName;

                CreateAirport(airport);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(airport);
            }
        }
        private void CreateAirport(AirportCreateVm airport)
        {
            var service = new AirportService(efRepository); //告訴service要用接收哪個資料庫

            AirportDto dto = new AirportDto
            {
                Id = airport.Id,
                Lata = airport.Lata,
                Gps = airport.Gps,
                Country = airport.Country,
                City = airport.City,
                AirPortName = airport.AirPortName,
                TimeArea = airport.TimeArea,
                Zone = airport.Zone,
                CityIntroduction = airport.CityIntroduction,
                Img = airport.Img,
                Continent = airport.Continent,
            };
            service.Create(dto);
        }

        #endregion  



        public ActionResult Details(int id)
        {
            AirportCreateVm vm = Get(id);
            return View(vm);
        }


        #region edit
        public ActionResult Edit(int id)
        {
            var airport = Get(id);
            return View(airport);
        }

        [HttpPost]
        public ActionResult Edit(AirportCreateVm airport, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) return View(airport);

            string path = Server.MapPath("~/Files/Airports");
            var helper = new UploadImgHelper();

            try
            {
                string newFileName = helper.SaveAs(path, file);
                //airport.Image = System.IO.Path.GetFileName(newFileName);
                airport.Img = newFileName;

                Update(airport);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);

                airport.Img = string.Empty;
            }
            Update(airport);
            return View(airport);
        }

        private void Update(AirportCreateVm airport)
        {
            var service = new AirportService(efRepository);
            AirportDto dto = new AirportDto
            {
                Id = airport.Id,
                Lata = airport.Lata,
                Gps = airport.Gps,
                Country = airport.Country,
                City = airport.City,
                AirPortName = airport.AirPortName,
                TimeArea = airport.TimeArea,
                Zone = airport.Zone,
                CityIntroduction = airport.CityIntroduction,
                Img = airport.Img,
                Continent = airport.Continent,
            };
            service.Update(dto);
        }

        #endregion











        private AirportCreateVm Get(int id)
        {
            var service = new AirportService(efRepository);
            var get = service.Get(id);

            return new AirportCreateVm
            {
                Id = get.Id,
                Lata = get.Lata,
                Gps = get.Gps,
                Country = get.Country,
                City = get.City,
                AirPortName = get.AirPortName,
                TimeArea = get.TimeArea,
                Zone = get.Zone,
                CityIntroduction = get.CityIntroduction,
                Img = get.Img,
                Continent = get.Continent,
            };
        }



    }
}