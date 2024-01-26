using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers.AirFlight
{
    public class AirFlightsController : Controller
    {
        // GET: AirFlights
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {

            return View();
        }
    }
}