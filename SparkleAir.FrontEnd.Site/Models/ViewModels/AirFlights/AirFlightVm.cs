using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.ViewModels.AirFlights
{
    public class AirFlightVm
    {
        public int Id { get; set; }
        public int AirOwnId { get; set; }
        public int AirFlightManagementId { get; set; }

        [Display(Name = "起飛時間")]
        public DateTime ScheduledDeparture { get; set; }

        [Display(Name = "抵達時間")]
        public DateTime ScheduledArrival { get; set; }

        public int AirFlightSaleStatusId { get; set; }

        //from Airtypes 寫委派轉型
        //from AirOwnId => AirTypeId => flightModel
        [Display(Name = "機型")]
        public string FlightModel { get; set; }

        [Display(Name = "航班編號")]
        public string FlightCode { get; set; }

        [Display(Name = "出發地")]
        public string DepartureAirPort { get; set; }

        [Display(Name = "目的地")]
        public string ArrivalAriPort { get; set; }

        [Display(Name = "目的地")]
        public string AirFlightSaleStatus { get; set; }
    }
}