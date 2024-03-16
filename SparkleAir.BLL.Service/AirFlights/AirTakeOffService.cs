using SparkleAir.DAL.DapperRepository.AirFlights;
using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
    public class AirTakeOffService
    {
        private readonly IAirTakeOffRepository _repo;
        private readonly IAirFlightRepository _airFlightRepo;
        public AirTakeOffService(IAirTakeOffRepository repo)
        {
            _repo = repo;
            _airFlightRepo = new AirFlightDapperRepository();
        }
        public async Task Create(int id,DateTime ScheduledDeparture, DateTime ScheduledArrival)
        {
                AirTakeOffEntity entity = new AirTakeOffEntity
                {
                    AirFlightId =id,
                    ActualArrivalTime = ScheduledArrival,
                    ActualDepartureTime =ScheduledDeparture,
                    AirFlightStatusId = 1
                };
                _repo.CreateAirTakeOff(entity);
        }
    }
}
