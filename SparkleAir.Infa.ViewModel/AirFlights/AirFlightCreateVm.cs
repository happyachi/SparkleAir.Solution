using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class AirFlightCreateVm
    {
        public int Id { get; set; }

        public int AirOwnId { get; set; }  //要有一定要有 todo
        public int AirFlightManagementId { get; set; }

        [Display(Name = "航班編號")]
        public string FlightCode { get; set; }

        //from AirOwnId => AirTypeId => flightModel
        [Display(Name = "機型")]
        public string FlightModel { get; set; }

       
        public string RegistrationNum { get; set; }

        [Display(Name = "出發地")]
        public string DepartureAirport { get; set; }

        [Display(Name = "目的地")]
        public string ArrivalAirport { get; set; }

        [Display(Name = "起飛時間")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ScheduledDeparture { get; set; }

        [Display(Name = "抵達時間")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ScheduledArrival { get; set; }

        public string DayofWeek { get; set; }

        public int DepartureTimeZone { get; set; }
        public int ArrivalTimeZone { get; set; }
        public int CrossDay {  get; set; }
    }
}
