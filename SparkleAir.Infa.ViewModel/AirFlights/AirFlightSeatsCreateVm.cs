using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class AirFlightSeatsCreateVm
    {
        public int Id { get; set; }
        public int AirFlightId { get; set; }
        public int AirCabinId { get; set; }
        public string SeatNum { get; set; }
        public bool IsSeated { get; set; }
    }
}
