using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Utility.Helper;
using SparkleAir.Infa.ViewModel.AirFlights;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
    public class AirFlightsController : BaseController
    {
        #region CTOR

        private IAirFlightRepository _repo;
        private AirFlightService _service;
        private IAirFlightManagementRepository _flightManagementRepo;
        private AirFlightManagementService _flightManagementService;
        public AirFlightsController()
        {
            _repo = new AirFlightEFRepository();
            _flightManagementRepo = new AirFlightManagementEFRepository();
            _flightManagementService = new AirFlightManagementService(_flightManagementRepo);
            _service = new AirFlightService(_repo);

        }

        #endregion
        // GET: AirFlights
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            AirFlightCreateVm data = Get(id);
            return View(data);
        }

        private AirFlightCreateVm Get(int id)
        {
            var vm = _flightManagementService.GetById(id);
            FlightDate[] flightDays = vm.DayofWeek.FlightDays();

            // 計算從今天開始的下一班飛機日期
            DateTime nextFlightDate = CalculateNextFlightDate(flightDays);
            var flight = new AirFlightCreateVm
            {
                Id = vm.Id,
                AirFlightManagementId = id,
                FlightModel = vm.FlightModel,
                FlightCode = vm.FlightCode,
                DepartureAirport = vm.DepartureAirport,
                ArrivalAirport = vm.ArrivalAirport,
                DayofWeek = vm.DayofWeek,
                // 將下一班飛機日期和飛行時間結合
                ScheduledDeparture = nextFlightDate.Add(vm.DepartureTime),
                ScheduledArrival = nextFlightDate.Add(vm.ArrivalTime),
                DepartureTimeZone = vm.DepartureTimeZone,
                ArrivalTimeZone = vm.ArrivalTimeZone
            };
            return flight;
        }
        private DateTime CalculateNextFlightDate(FlightDate[] days)
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            List<DayOfWeek> flightDays = new List<DayOfWeek>(days.Select(d => (DayOfWeek)d)); // 將 FlightDate 轉換為 DayOfWeek

            while (true)
            {
                if (flightDays.Contains(tomorrow.DayOfWeek))
                {
                    // 找到了符合條件的日期
                    return tomorrow;
                }
                tomorrow = tomorrow.AddDays(1);
            }
        }

        [HttpPost]
        public ActionResult Create(AirFlightCreateVm vm)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                CreateFlight(vm);
                return RedirectToAction("Index","AirFlightsManagement");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private void CreateFlight(AirFlightCreateVm vm)
        {
            AirFlightDto dto = new AirFlightDto
            {
                Id = vm.Id,
                AirOwnId = vm.AirOwnId,
                AirFlightManagementId = vm.AirFlightManagementId,
                FlightCode = vm.FlightCode,
                FlightModel = vm.FlightModel,
                DepartureAirport = vm.DepartureAirport,
                ArrivalAirport = vm.ArrivalAirport,
                ScheduledDeparture = vm.ScheduledDeparture,
                ScheduledArrival = vm.ScheduledArrival,
                AirFlightSaleStatusId = 1,
                DayofWeek = vm.DayofWeek,
                DepartureTimeZone = vm.DepartureTimeZone,
                ArrivalTimeZone = vm.ArrivalTimeZone
            };

            _service.Create(dto);
        }
    }
}