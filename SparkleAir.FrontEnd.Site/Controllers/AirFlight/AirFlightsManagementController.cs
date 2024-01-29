﻿using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.DAL.DapperRepository.AirFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Utility.Helper;
using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.ViewModel.AirFlights;

namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
    public class AirFlightsManagementController : Controller
    {
        #region CTOR

        private IAirFlightManagementRepository _repo;
        private AirFlightManagementService _service;

        public AirFlightsManagementController()
        {
            //EF
            _repo = new AirFlightManagementEFRepository();

            //DP
            //_repo = new AirFlightDapperRepository();
            _service = new AirFlightManagementService(_repo);
        }

        //for testing
        public AirFlightsManagementController(AirFlightManagementService service)
        {
            _service = service;
        }

        #endregion

        #region Index

        // GET: AirFlights
        public ActionResult Index()
        {
            List<AirFlightManagementIndexVm> data = GetAll();
            return View(data);
        }

        private List<AirFlightManagementIndexVm> GetAll()
        {
            List<AirFlightManagementDto> dto = _service.GetAll();
            List<AirFlightManagementIndexVm> vm = dto.Select(x => new AirFlightManagementIndexVm
            {
                Id = x.Id,
                FlightCode = x.FlightCode,
                DepartureAirport = x.DepartureAirport,
                ArrivalAirport = x.ArrivalAirport,
                DepartureTime = x.DepartureTime,
                ArrivalTime = x.ArrivalTime,
                DayofWeek = x.DayofWeek,
            }).ToList();
            return vm;
        }

        public ActionResult Create()
        {
            return View();
        }

        #endregion

        #region Create
        [HttpPost]
        public ActionResult Create(AirFlightManagementVm vm)
        {
            try
            {
                CreateFlight(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private void CreateFlight(AirFlightManagementVm vm)
        {
            AirFlightManagementDto dto = new AirFlightManagementDto
            {
                Id = vm.Id,
                FlightCode = vm.FlightCode,
                DepartureAirport = vm.DepartureAirport,
                DepartureAirportId = vm.DepartureAirportId,
                ArrivalAirport = vm.ArrivalAirport,
                ArrivalAirportId = vm.ArrivalAirportId,
                DepartureTime = vm.DepartureTime,
                ArrivalTime = vm.ArrivalTime,
                DayofWeek = vm.DayofWeek,
                Mile = vm.Mile,
                DepartureTimeZone = vm.DepartureTimeZone,
                ArrivalTimeZone = vm.ArrivalTimeZone
            };

            _service.Create(dto);
        }
        #endregion

        #region Edit With Update
        public ActionResult Edit(int id)
        {
            try
            {
                AirFlightManagementVm vm = Get(id);
                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }

        private AirFlightManagementVm Get(int id)
        {
            AirFlightManagementDto dto = _service.GetById(id);
            AirFlightManagementVm vm = new AirFlightManagementVm
            {
                Id = id,
                FlightCode = dto.FlightCode,
                DepartureAirport = dto.DepartureAirport,
                DepartureAirportId = dto.DepartureAirportId,
                ArrivalAirport = dto.ArrivalAirport,
                ArrivalAirportId = dto.ArrivalAirportId,
                DepartureTerminal = dto.DepartureTerminal,
                ArrivalTerminal = dto.ArrivalTerminal,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime,
                DayofWeek = dto.DayofWeek,
                Mile = dto.Mile,
                DepartureTimeZone = dto.DepartureTimeZone,
                ArrivalTimeZone = dto.ArrivalTimeZone,
                AriOwnId = (int)dto.AirOwnId
            };
            return vm;
        }

        [HttpPost]
        public ActionResult Edit(AirFlightManagementVm vm)
        {

            if (!ModelState.IsValid) return View(vm);

            try
            {
                Update(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private void Update(AirFlightManagementVm vm)
        {
            AirFlightManagementDto dto = new AirFlightManagementDto
            {
                Id = vm.Id,
                FlightCode = vm.FlightCode,
                DepartureAirport = vm.DepartureAirport,
                DepartureAirportId = vm.DepartureAirportId,
                ArrivalAirport = vm.ArrivalAirport,
                ArrivalAirportId = vm.ArrivalAirportId,
                DepartureTerminal = vm.DepartureTerminal,
                ArrivalTerminal = vm.ArrivalTerminal,
                DepartureTime = vm.DepartureTime,
                ArrivalTime = vm.ArrivalTime,
                DayofWeek = vm.DayofWeek,
                Mile = vm.Mile,
                DepartureTimeZone = vm.DepartureTimeZone,
                ArrivalTimeZone = vm.ArrivalTimeZone
            };

            _service.Update(dto);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                DeleteFlight(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
        }

        private void DeleteFlight(int id)
        {
            _service.Delete(id);
        }
        #endregion

        #region Search
        public ActionResult SearchPartial(AirFlightManagementSearchCriteria vm)
        {
            var viewModel = SearchAirFlights(vm);
            return PartialView("_SearchPartial", viewModel);
        }
        private List<AirFlightManagementIndexVm> SearchAirFlights(AirFlightManagementSearchCriteria vm)
        {
            var list = _service.Search(vm);

            return list.Select(data => new AirFlightManagementIndexVm
            {
                Id = data.Id,
                FlightCode = data.FlightCode,
                DepartureAirport = data.DepartureAirport,
                ArrivalAirport = data.ArrivalAirport,
                DepartureTime = data.DepartureTime,
                ArrivalTime = data.ArrivalTime,
                DayofWeek = data.DayofWeek.ToString()
            }).ToList();
        }
        #endregion

        #region Details
        public ActionResult DetailsPartial(int id)
        {
            // 根據ID獲取另一個VM的數據
            var viewModel = _service.GetById(id);
            if (viewModel.FlightModel == "")
            {
                viewModel.FlightModel = "未設定";
            }
            return PartialView("_DetailsPartial", viewModel);
        }
        #endregion
    }
}