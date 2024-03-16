using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirTakeOffEFRepository:IAirTakeOffRepository
    {
        private AppDbContext db;
        public AirTakeOffEFRepository()
        {
            db = new AppDbContext();
        }
        public void CreateAirTakeOff(AirTakeOffEntity entity)
        {
            AirTakeOffStatus status = new AirTakeOffStatus
            {
                Id = entity.Id,
                AirFlightId = entity.AirFlightId,
                ActualArrivalTime = entity.ActualArrivalTime,
                ActualDepartureTime = entity.ActualDepartureTime,
                AirFlightStatusId = entity.AirFlightStatusId
            };
            db.AirTakeOffStatuses.Add(status);
            db.SaveChanges();
        }
    }
}
