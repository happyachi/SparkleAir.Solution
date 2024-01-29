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
        public AirFlightSeatsController()
        {
            _seatGroupRepo = new SeatGroupEFRepository();
            _seatGroupService = new SeatGroupService(_seatGroupRepo);

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

        public ActionResult CreateFlightSeats()
        {
            return View();
        }
    }
}