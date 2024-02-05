using SparkleAir.BLL.Service.Airports;
using SparkleAir.BLL.Service.Luggage;
using SparkleAir.DAL.EFRepository.Airports;
using SparkleAir.DAL.EFRepository.Luggages;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.Airport;
using SparkleAir.IDAL.IRepository.Luggage;
using SparkleAir.Infa.Dto.Airport;
using SparkleAir.Infa.Dto.Luggage;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.ViewModel.Airports;
using SparkleAir.Infa.ViewModel.Luggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.Luggages
{
    [StaffAuthorize(PageName = "Luggage")]
    public class LuggageController : BaseController
    {

        ILuggageRepository efRLuggage = new LuggageEFRepository();
       
        // GET: Luggage
        public ActionResult Index()
        {
            List<LuggageIndexVm> data = GetAll();
            return View(data);
        }

        private List<LuggageIndexVm> GetAll()
        {
            var service = new LuggageService(efRLuggage); //告訴service要用接收哪個資料庫

            List<LuggageDto> dto = service.GetAll();

            List<LuggageIndexVm> vm = dto.Select(p => new LuggageIndexVm
            {
                Id = p.Id,
                AirFlightManagementsId= p.AirFlightManagementsId,
                OriginalPrice = p.OriginalPrice,
                BookPrice = p.BookPrice,

            }).ToList();

            return vm;
        }


        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LuggageCreateVm luggage)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                CreateAirport(luggage);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(luggage);
            }
        }
        private void CreateAirport(LuggageCreateVm luggage)
        {
            var service = new LuggageService(efRLuggage); //告訴service要用接收哪個資料庫

            LuggageDto dto = new LuggageDto
            {
                Id = luggage.Id,
                AirFlightManagementsId = luggage.AirFlightManagementsId,
                OriginalPrice = luggage.OriginalPrice,
                BookPrice = luggage.BookPrice,
            };
            service.Create(dto);
        }

        #endregion


        #region Delete
        public ActionResult Delete(int id)
        {

            DeleteLuggage(id);
            return RedirectToAction("Index");

        }
        private void DeleteLuggage(int id)
        {
            var service = new LuggageService(efRLuggage); //告訴service要用接收哪個資料庫
            service.Delete(id);
        }
        #endregion





        #region Edit

        private LuggageCreateVm Get(int id)
        {
            var service = new LuggageService(efRLuggage);
            var get = service.Get(id);

            return new LuggageCreateVm
            {
                Id = get.Id,
                AirFlightManagementsId = get.AirFlightManagementsId,
                OriginalPrice = get.OriginalPrice,
                BookPrice = get.BookPrice,
            };
        }
        public ActionResult Edit(int id)
        {
            var luggage = Get(id);
            return View(luggage);
        }

        [HttpPost]
        public ActionResult Edit(LuggageCreateVm luggage)
        {
            if (!ModelState.IsValid) return View(luggage);
            try
            {
                Update(luggage);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(luggage);
        }

        private void Update(LuggageCreateVm luggage)
        {
            var service = new LuggageService(efRLuggage);
            LuggageDto dto = new LuggageDto
            {
                Id = luggage.Id,
                AirFlightManagementsId = luggage.AirFlightManagementsId,
                OriginalPrice = luggage.OriginalPrice,
                BookPrice = luggage.BookPrice,
            };
            service.Update(dto);
        }

      


#endregion



    }
}