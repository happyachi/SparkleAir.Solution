using SparkleAir.BLL.Service.AirFlights;
using SparkleAir.DAL.EFRepository.AirFlights;
using SparkleAir.IDAL.IRepository.AirFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
    public class AirFlightSeatsController : Controller
    {
        private ISeatGroupRepository _seatGroupRepo;
        private SeatGroupService _seatGroupService;
        private IAirFlightSeatsRepository _airFlightSeatsRepo;
        private AirFlightSeatsService _airFlightSeatsService;
        public AirFlightSeatsController()
        {
            _seatGroupRepo = new SeatGroupEFRepository();
            _seatGroupService = new SeatGroupService(_seatGroupRepo);
            _airFlightSeatsRepo = new AirFlightSeatsEFRepository();
            _airFlightSeatsService = new AirFlightSeatsService(_airFlightSeatsRepo);
        }


        // GET: AirFlightSeats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSeatGroup()
        {
            _seatGroupService.Create();
            return View();
        }

        public ActionResult CreateFlightSeats(int FlightId)
        {
            _airFlightSeatsService.Create777300ER(FlightId);
            return View();
        }
    }
}