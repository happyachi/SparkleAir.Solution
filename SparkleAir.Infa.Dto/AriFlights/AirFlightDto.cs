using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.AriFlights
{
	public class AirFlightDto
	{
		public int Id { get; set; }
		public int AirOwnId { get; set; }
		public int AirFlightManagementId { get; set; }
		public DateTime ScheduledDeparture { get; set; }
		public DateTime ScheduledArrival { get; set; }
		public int AirFlightSaleStatusId { get; set; }

		//from Airtypes 寫委派轉型
		//from AirOwnId => AirTypeId => flightModel
		public string FlightModel { get; set; }
		public string FlightCode { get; set; }
        public string DepartureAirPort { get; set; }
        public string ArrivalAirPort { get; set; }
        public string AirFlightSaleStatus { get; set; }
	}
}
