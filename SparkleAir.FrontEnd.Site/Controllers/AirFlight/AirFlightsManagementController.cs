using SparkleAir.IDAL.IRepository.AirFlights;
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
using SparkleAir.IDAL.IRepository.Airport;
using SparkleAir.BLL.Service.Airports;
using SparkleAir.DAL.EFRepository.Airports;
using System.Threading.Tasks;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.Infa.EFModel.EFModels;
using System.Data.Entity;
namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
    [StaffAuthorize(PageName = "AirFlightsManagement")]
    public class AirFlightsManagementController : BaseController
    {
        #region CTOR

        private IAirFlightManagementRepository _repo;
        private AirFlightManagementService _service;
        private IAirTicketPriceRepository _priceRepository;
        private AirTicketPriceService _priceService;

        private IAirportRepository _airportRepo;
        private AirportService _airportService;

        public AirFlightsManagementController()
        {
            _repo = new AirFlightManagementEFRepository();
            _service = new AirFlightManagementService(_repo);

            _priceRepository = new AirTicketPriceEFRepository();
            _priceService = new AirTicketPriceService(_priceRepository);

            _airportRepo = new AirportEFRepository();
            _airportService = new AirportService(_airportRepo);
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
            ViewBag.Airports = _airportService.GetAll();
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

        #endregion

        #region Create With Price for each Cabin

        public ActionResult Create()
        {
            ViewBag.Airports = _airportService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AirFlightManagementCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
            };
            ViewBag.Airports = _airportService.GetAll();
            try
            {
                var flightId = CreateFlight(vm);
                await _priceService.CreateTicketPirce(flightId, vm.Mile);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(new { success = false, errors = new[] { ex.Message } });
            }

        }

        private int CreateFlight(AirFlightManagementCreateVm vm)
        {
            AirFlightManagementDto dto = new AirFlightManagementDto
            {
                Id = vm.Id,
                FlightCode = vm.FlightCode,
                DepartureAirport = vm.DepartureAirport,
                ArrivalAirport = vm.ArrivalAirport,
                DepartureTime = vm.DepartureTime,
                DepartureTerminal = vm.DepartureTerminal,
                ArrivalTerminal = vm.ArrivalTerminal,
                ArrivalTime = vm.ArrivalTime,
                DayofWeek = vm.DayofWeek,
                Mile = vm.Mile,
                DepartureTimeZone = vm.DepartureTimeZone,
                ArrivalTimeZone = vm.ArrivalTimeZone,
                CrossDay = vm.CrossDay
            };

            var flightId = _service.Create(dto);
            return flightId;
        }
        #endregion

        #region Edit With Update
        public ActionResult Edit(int id)
        {
            try
            {
                AirFlightManagementVm vm = Get(id);
                ViewBag.AirFlightEdit = Get(id);
                ViewBag.Airports = _airportService.GetAll();
                //return Json(vm, JsonRequestBehavior.AllowGet);
                return View(vm);
                //return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(new { error = ex.Message });
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
                AirOwnId = (int)dto.AirOwnId
            };
            return vm;
        }

        [HttpPost]
        public ActionResult Edit(AirFlightManagementVm vm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
            };
            ViewBag.Airports = _airportService.GetAll();
            try
            {
                Update(vm);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(new { success = false, errors = new[] { ex.Message } });
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
        public ActionResult Search(AirFlightManagementSearchCriteria vm)
        {
            var datas = SearchAirFlights(vm);
            return Json(datas, JsonRequestBehavior.AllowGet);
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

        public ActionResult GetFlightDetails(int id)
        {
            var flightDetail = _service.GetById(id);
            return Json(flightDetail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPrice(int id)
        {
            AppDbContext db = new AppDbContext();
            List<AirTicketPriceVm> ticketPrice = db.AriTicketPrices
                .Include(x => x.AirFlightManagement)
                .Include(x => x.AirCabinRule)
                .Include(x => x.AirCabinRule.AirCabin)
                .Where(x => x.AirFlightManagementId == id)
                .Select(x => new AirTicketPriceVm
                {
                    FlightCode = x.AirFlightManagement.FlightCode,
                    CabinName = x.AirCabinRule.AirCabin.CabinClass,
                    CabinCode = x.AirCabinRule.CabinCode,
                    Price = x.Price
                }).ToList();
            return Json(ticketPrice, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}