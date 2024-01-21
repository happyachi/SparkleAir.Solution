using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.AriFlights
{
	public class AirFlightManagementDto
	{
		public int Id { get; set; }

		public string FlightCode { get; set; }

		public int DepartureAirportId { get; set; }

		public int DestinationAirportId { get; set; }

		public string DepartureTerminal { get; set; }

		public string DestinationTerminal { get; set; }

		public DateTime DepartureTime { get; set; }

		public DateTime ArrivalTime { get; set; }

		public string DayofWeek { get; set; }

		public int Mile { get; set; }

		public string DepartureAirport { get; set; }
		public string DestinationAirport { get; set; }
	}
}
