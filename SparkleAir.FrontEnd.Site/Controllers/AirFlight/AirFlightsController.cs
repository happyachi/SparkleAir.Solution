
using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.BLL.Service.Airtype_Owns;
using SparkleAir.DAL.DapperRepository.AirFlights;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.DAL.EFRepository.Airtype_Owns;
using SparkleAir.FrontEnd.Site.Models.Authorize;
using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.IDAL.IRepository.Airtype_Owns;
using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Utility.Helper;
using SparkleAir.Infa.ViewModel.AirFlights;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
    [StaffAuthorize(PageName = "AirFlights")]
    public class AirFlightsController : BaseController
    {
        #region CTOR

        private IAirFlightRepository _airFlightRepo;
        private AirFlightService _airFlightService;
        private IAirFlightRepository _airDPFlightRepo;
        private AirFlightService _airDPFlightService;

        private IAirFlightManagementRepository _flightManagementRepo;
        private AirFlightManagementService _flightManagementService;

        private IAirFlightSeatsRepository _flightSeatsRepo;
        private AirFlightSeatsService _flightSeatsService;

        private IAirSeatRepository _airSeatRepo;
        private AirSeatService _airSeatService;

        private IPlaneRepository _planeRepo;
        private PlaneService _planeService;


        public AirFlightsController()
        {
            _airFlightRepo = new AirFlightEFRepository();
            _flightManagementRepo = new AirFlightManagementEFRepository();
            _flightManagementService = new AirFlightManagementService(_flightManagementRepo);
            _airFlightService = new AirFlightService(_airFlightRepo);
            _flightSeatsRepo = new AirFlightSeatsEFRepository();
            _flightSeatsService = new AirFlightSeatsService(_flightSeatsRepo);
            _airSeatRepo = new AirSeatRepository();
            _airSeatService = new AirSeatService(_airSeatRepo);

            _planeRepo = new PlaneRepository();
            _planeService = new PlaneService(_planeRepo);

            _airDPFlightRepo = new AirFlightDapperRepository();
            _airDPFlightService = new AirFlightService(_airDPFlightRepo);
        }
        #endregion

        #region Index

        public ActionResult Index()
        {
            return View();

        }
        public async Task<ActionResult> Index1()
        {
            try
            {
                List<AirFlightIndexVm> datas =await GetAll();

                _ = Task.Run(() => UpdateAndRetrieveSchedule());  // 在後台跑班表

                //return View(datas);
                return PartialView("Index1", datas);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }
        private async Task<List<AirFlightIndexVm>> GetAll()
        {
            List<AirFlightDto> dtoList = await _airDPFlightService.GetAllAsync();

            // 使用非同步方式進行 SaleStatus 的更新
            await Task.WhenAll(dtoList.Select(dto => _airFlightService.UpdateSaleStatusAsync(dto)));

            List<AirFlightIndexVm> vmList = dtoList.Select(dto => new AirFlightIndexVm
            {
                Id = dto.Id,
                FlightCode = dto.FlightCode,
                FlightModel = dto.FlightModel,
                DepartureAirport = dto.DepartureAirport,
                ArrivalAirport = dto.ArrivalAirport,
                ScheduledDeparture = dto.ScheduledDeparture,
                ScheduledArrival = dto.ScheduledArrival,
                RegistrationNum = dto.RegistrationNum,
                CrossDay = dto.CrossDay
            }).ToList();

            return vmList;
        }

        private async Task<List<AirFlightIndexVm>> UpdateAndRetrieveSchedule()
        {
            List<AirFlightDto> dto = _airDPFlightService.GetAll();
            List<(int, string)> updatedFlights = new List<(int, string)>();

            foreach (var item in dto)
            {
                List<(int, string)> updatedIds = await _airFlightService.UpdateScheduleIfNeeded(item);
                foreach (var id in updatedIds)
                {
                    // 在更新循環中創建座位
                    await _flightSeatsService.CreateSeats(id.Item1, id.Item2);
                }
            }

            List<AirFlightIndexVm> vm = dto.Select(x => new AirFlightIndexVm
            {
                
            }).ToList();

            return vm;
        }

        //public ActionResult CalendarPartial()
        //{
        //    List<AirFlightIndexVm> datas = GetAll();
        //    return PartialView("_CalendarPartial", datas);
        //}

        #endregion

        #region Create & Connect AirOwnId & Create Flight Model Seats
        //先 get AirFlightManagementVm 的資料 => 設定AirOwnID(FlightModel) => Create 2個月內的班表 
        public ActionResult Create(int id)
        {
            var db = new AppDbContext();
            ViewBag.AirOwn = db.AirOwns.Select(x => new AirOwnVm
            {
                FlightModel = x.AirType.FlightModel,
                RegistrationNum = x.RegistrationNum,
                Status = x.Status
            }).ToList();
            AirFlightCreateVm data = GetFlight(id);
            return View(data);
        }


        private AirFlightCreateVm GetFlight(int id)
        {
            var vm = _flightManagementService.GetById(id);
            FlightDate[] flightDays = vm.DayofWeek.FlightDays();

            // 計算從今天開始的下一班飛機日期
            DateTime nextFlightDate = CalculateNextFlightDate(flightDays);
            var flight = new AirFlightCreateVm
            {
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
                ArrivalTimeZone = vm.ArrivalTimeZone,
                RegistrationNum = vm.RegistrationNum,
                CrossDay = vm.CrossDay
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
        public async Task<ActionResult> Create(AirFlightCreateVm vm)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                List<(int, string)> flightIds = await CreateFlight(vm);
                foreach (var flightId in flightIds)
                {
                    await _flightSeatsService.CreateSeats(flightId.Item1, flightId.Item2);
                }
                return RedirectToAction("Index", "AirFlightsManagement");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        private async Task<List<(int, string)>> CreateFlight(AirFlightCreateVm vm)
        {
            List<(int, string)> flights;
            AirFlightDto dto = new AirFlightDto
            {
                AirOwnId = vm.AirOwnId,
                AirFlightManagementId = vm.AirFlightManagementId,
                FlightCode = vm.FlightCode,
                FlightModel = vm.FlightModel,
                DepartureAirport = vm.DepartureAirport,
                ArrivalAirport = vm.ArrivalAirport,
                ScheduledDeparture = vm.ScheduledDeparture,
                ScheduledArrival = vm.ScheduledArrival.AddDays(vm.CrossDay),
                AirFlightSaleStatusId = 1, // 預設為 1 (銷售中)
                DayofWeek = vm.DayofWeek,
                DepartureTimeZone = vm.DepartureTimeZone,
                ArrivalTimeZone = vm.ArrivalTimeZone,
                RegistrationNum = vm.RegistrationNum,
                CrossDay = vm.CrossDay
            };
            flights = await _airFlightService.Create(dto);
            return flights;
        }

        #endregion

        #region Create More Flights
        //todo
        #endregion

        #region Get Seat Info
        public ActionResult GetSeat(int id)
        {
            try
            {
                //List<AirFlightSeatsVm> vm = GetSeatInfo(id);
                var model = _airFlightService.GetById(id);
                EachFlightSeatsVm vm = new EachFlightSeatsVm
                {
                    DepartureAirport = model.DepartureAirport,
                    ArrivalAirport = model.ArrivalAirport,
                    ScheduledArrival = model.ScheduledArrival,
                    ScheduledDeparture = model.ScheduledDeparture,
                    Seats = GetSeatInfo(model.Id)
                };
                //return Json(vm,JsonRequestBehavior.AllowGet);
                return View(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }

        private List<AirFlightSeatsVm> GetSeatInfo(int FlightId)
        {
            List<AirFlightSeatsDto> dto = _flightSeatsService.GetById(FlightId);
            List<AirFlightSeatsVm> vms = dto.Select(v => new AirFlightSeatsVm
            {
                Id = v.Id,
                FlightId = FlightId,
                FlightModel = v.FlightModel,
                RegisterNum = v.RegisterNum,
                CabinName = v.CabinName,
                SeatNum = v.SeatNum,
                IsSeated = v.IsSeated,
            }).ToList();
            return vms;
        }

        public ActionResult SeatsDetailPartial(int id)
        {
            var model = _flightSeatsService.GetEachSeatInfo(id);
            model.Gender = (model.Gender == "0") ? "男" : "女";
            model.CheckInstatus = (model.CheckInstatus == "1") ? "已報到" : "未報到";
            return Json(model, JsonRequestBehavior.AllowGet);
            //return PartialView("_SeatsDetailPartial", model);
        }

        #endregion
    }
}