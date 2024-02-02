using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class AirFlightVm
    {
        public int Id { get; set; }
        public int AirOwnId { get; set; }
        public int AirFlightManagementId { get; set; }

        [Display(Name = "起飛時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ScheduledDeparture { get; set; }

        [Display(Name = "抵達時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ScheduledArrival { get; set; }

        public int AirFlightSaleStatusId { get; set; }

        [Display(Name = "機型")]
        public string FlightModel { get; set; }

        [Display(Name = "航班編號")]
        public string FlightCode { get; set; }

        [Display(Name = "出發地")]
        public string DepartureAirPort { get; set; }

        [Display(Name = "目的地")]
        public string ArrivalAriPort { get; set; }

        [Display(Name = "銷售狀態")]
        public string AirFlightSaleStatus { get; set; }
    }
}
