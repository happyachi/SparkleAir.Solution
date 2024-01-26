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
        public TimeSpan DepartureStartTime { get; set; }
        public TimeSpan DepartureEndTime { get; set; }
        public TimeSpan ArrivalStartTime { get; set; }
        public TimeSpan ArrivalEndTime { get; set; }
        public FlightDays FlightDays { get; set; }
    }
}