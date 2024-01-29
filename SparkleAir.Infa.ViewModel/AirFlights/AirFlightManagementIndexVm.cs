using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class AirFlightManagementIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "班次代碼")]
        public string FlightCode { get; set; }

        [Display(Name = "出發地")]
        public string DepartureAirport { get; set; }

        [Display(Name = "目的地")]
        public string ArrivalAirport { get; set; }

        [Display(Name = "出發時間")]
        public TimeSpan DepartureTime { get; set; }

        [Display(Name = "抵達時間")]
        public TimeSpan ArrivalTime { get; set; }

        [Display(Name = "執飛日")]
        public string DayofWeek { get; set; }
    }
}
