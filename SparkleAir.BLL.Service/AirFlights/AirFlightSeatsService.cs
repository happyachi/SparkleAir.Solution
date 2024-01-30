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
    public class AirFlightSeatsService
    {
        private readonly IAirFlightSeatsRepository _repo;
        public AirFlightSeatsService(IAirFlightSeatsRepository repo)
        {
            _repo = repo;
        }
        public void Create777300ER(int flightId)
        {
            _repo.Create777300ER(flightId);
        }

        public List<AirFlightSeatsDto> GetById(int flightId)
        {
            List<AirFlightSeatsEntity> entity = _repo.GetByFlightId(flightId);
            List<AirFlightSeatsDto> dto = entity.Select(s => new AirFlightSeatsDto
            {
                Id = s.Id,
                AirFlightId = flightId,
                AirCabinId = s.AirCabinId,
                SeatNum = s.SeatNum,
                IsSeated = s.IsSeated,
                FlightModel = s.FlightModel,
                RegisterNum = s.RegisterNum,
                CabinName = s.CabinName,
            }).ToList();
            return dto;
        }
    }
}
