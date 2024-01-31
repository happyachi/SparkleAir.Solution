using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.IDAL.IRepository.AirFlights
{
    public interface IAirFlightSeatsRepository
    {
        Task Create777300ER(int flightId);
        List<AirFlightSeatsEntity> GetByFlightId(int flightId);

        EachSeatInfoEntity GetEachSeatInfo(int seatId);
    }
}
