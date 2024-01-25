﻿using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.DAL.DapperRepository.AirFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.FrontEnd.Site.Models.ViewModels.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;

namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
	public class AirFlightsController : Controller
	{
		#region CTOR

		private IAirFlightRepository _repo;
		private AirFlightService _service;

		public AirFlightsController()
		{
			//EF
			_repo = new AirFlightEFRepository();

			//DP
			//_repo = new AirFlightDapperRepository();
			_service = new AirFlightService(_repo);
		}

		//for testing
		public AirFlightsController(AirFlightService service)
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
				DestinationAirport = x.DestinationAirport,
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
			if (!ModelState.IsValid) return View();
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
				DestinationAirport = vm.DestinationAirport,
				DestinationAirportId = vm.DestinationAirportId,
				DepartureTime = vm.DepartureTime,
				ArrivalTime = vm.ArrivalTime,
				DayofWeek = vm.DayofWeek,
				Mile = vm.Mile,
				DepartureTimeZone = vm.DepartureTimeZone,
				DestinationTimeZone = vm.ArrivalTimeZone
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
				DestinationAirport = dto.DestinationAirport,
				DestinationAirportId = dto.DestinationAirportId,
				DepartureTerminal = dto.DepartureTerminal,
				DestinationTerminal = dto.DestinationTerminal,
				DepartureTime = dto.DepartureTime,
				ArrivalTime = dto.ArrivalTime,
				DayofWeek = dto.DayofWeek,
				Mile = dto.Mile,
				DepartureTimeZone = dto.DepartureTimeZone,
				ArrivalTimeZone = dto.DestinationTimeZone
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
				DestinationAirport = vm.DestinationAirport,
				DestinationAirportId = vm.DestinationAirportId,
				DepartureTerminal = vm.DepartureTerminal,
				DestinationTerminal = vm.DestinationTerminal,
				DepartureTime = vm.DepartureTime,
				ArrivalTime = vm.ArrivalTime,
				DayofWeek = vm.DayofWeek,
				Mile = vm.Mile,
				DepartureTimeZone = vm.DepartureTimeZone,
				DestinationTimeZone = vm.ArrivalTimeZone
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
        // todo
		private void Search()
		{

		}
        #endregion

        #region Details
        public ActionResult DetailsPartial(int id)
        {
            // 根據ID獲取另一個VM的數據
            var viewModel = _service.GetById(id);
            return PartialView("_DetailsPartial", viewModel);
        }
        #endregion
    }
}