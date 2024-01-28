using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class SeatConfiguration
    {
        public string FlightModel { get; set; }
        public int TotalSeats { get; set; }
        public Dictionary<string, int> CabinSeats { get; set; } = new Dictionary<string, int>();
    }
}
