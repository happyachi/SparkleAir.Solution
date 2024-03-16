using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.AriFlights
{
    public class AirTakeOffDto
    {
        public int Id { get; set; }

        public int AirFlightId { get; set; }

        public DateTime ActualDepartureTime { get; set; }

        public DateTime ActualArrivalTime { get; set; }

        public int AirFlightStatusId { get; set; }

        public string FlightCode { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureAirport { get; set; }
        public int DepartureTimeZone { get; set; }
        public int ArrivalTimeZone { get; set; }
    }
}
