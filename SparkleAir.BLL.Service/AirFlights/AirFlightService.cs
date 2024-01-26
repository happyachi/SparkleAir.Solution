using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
    public class AirFlightService
    {
        private readonly IAirFlightRepository _repo;
        public AirFlightService(IAirFlightRepository repo)
        {
            _repo = repo;
        }
        public void Create(AirFlightDto dto)
        {
            AirFlightEntity entity = new AirFlightEntity
            {
                Id = dto.Id,
                AirOwnId = dto.AirOwnId,
                FlightCode = dto.FlightCode,
                FlightModel = dto.FlightModel,
                DepartureAirPort = dto.DepartureAirPort,
                ArrivalAirPort = dto.ArrivalAirPort,
                ScheduledDeparture = dto.ScheduledDeparture,
                ScheduledArrival = dto.ScheduledArrival,
            };

            _repo.Create(entity);
        }

        public AirFlightDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
