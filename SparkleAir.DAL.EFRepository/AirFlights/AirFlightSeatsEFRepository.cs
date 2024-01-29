using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightSeatsEFRepository : IAirFlightSeatsRepository
    {
        public void Create(int managementId)
        {
            AirFlightSeatsEntity entity = new AirFlightSeatsEntity();

        }
    }
}
