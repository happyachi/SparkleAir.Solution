using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Entity.AirFlightsEntity
{
    public class AirTicketPriceEntity
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int AirCabinRuleId { get; set; }
        public int AirFlightManagementId { get; set; }
    }
}
