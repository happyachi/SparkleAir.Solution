using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Dto.AriFlights
{
    public class AirTicketPriceDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int AirCabinRuleId { get; set; }
        public int AirFlightManagementId { get; set; }
    }
}
