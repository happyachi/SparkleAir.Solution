using SparkleAir.IDAL.IRepository.AirFlights;
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
				DayofWeek = x.DayofWeek
			}).ToList();
			return vm;
		}

		public ActionResult Create()
		{
			return View();
		}

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
				DepartureAirportId = vm.DepartureAirportId,
				DestinationAirportId = vm.DestinationAirportId,
				DepartureTime = vm.DepartureTime,
				ArrivalTime = vm.ArrivalTime,
				DayofWeek = vm.DayofWeek,
				Mile = vm.Mile
			};

			_service.Create(dto);
		}
	}
}