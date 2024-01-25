using SparkleAir.Infa.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.AirFlights
{
    public class AirFlightManagementSearchVm
    {
        public string FlightCode { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public DateTime DepartureStartTime { get; set; }
        public DateTime DepartureEndTime { get; set; }
        public DateTime ArrivalStartTime { get; set; }
        public DateTime ArrivalEndTime { get; set; }
        public FlightDays FlightDays { get; set; }
    }
}