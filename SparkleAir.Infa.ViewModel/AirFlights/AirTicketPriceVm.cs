using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.ViewModel.AirFlights
{
    public class AirTicketPriceVm
    {
        public string FlightCode { get; set; }
        public string CabinName { get; set; }
        public string CabinCode { get; set; }
        public decimal Price { get; set; }
    }
}
