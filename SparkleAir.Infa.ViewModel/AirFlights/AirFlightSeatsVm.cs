using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class AirFlightSeatsVm
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string FlightModel { get; set; }
        public string RegisterNum { get; set; }
        public string CabinName { get; set; }
        public string SeatNum { get; set; }
        public bool IsSeated { get; set; }
    }
}
