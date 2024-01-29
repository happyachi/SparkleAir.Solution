using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using SparkleAir.Infa.Utility.Exts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightEFRepository : IAirFlightRepository
    {
        private AppDbContext db = new AppDbContext();
        private Func<AirFlight, AirFlightEntity> ToEntityFunc = (f) => f.ToAirFlightEntity();

        public void Create(AirFlightEntity entity)
        {
            AirFlight airFlight = new AirFlight
            {
                AirOwnId = (int)entity.FlightModel.GetAirOwnIdByFlightModel(db),
                AirFlightManagementId = entity.AirFlightManagementId,
                ScheduledDeparture = entity.ScheduledDeparture,
                ScheduledArrival = entity.ScheduledArrival,
                AirFlightSaleStatusId = entity.AirFlightSaleStatusId
            };
            db.AirFlights.Add(airFlight);
            db.SaveChanges();
        }

        public List<AirFlightEntity> GetAll()
        {
            var flights = db.AirFlights
                .AsNoTracking()
                .ToList()
                .Select(ToEntityFunc)
                .ToList();
            return flights;
        }

        public AirFlightEntity GetById(int id)
        {
            var flight = db.AirFlights.Find(id);
            var airplain = new AirFlightEntity
            {
                //todo
                Id = id,
                AirOwnId = flight.AirOwnId,
                AirFlightManagementId = flight.AirFlightManagementId,
                ScheduledArrival = flight.ScheduledArrival,
                ScheduledDeparture = flight.ScheduledDeparture,
                AirFlightSaleStatusId = flight.AirFlightSaleStatusId
            };
            return airplain;
        }
    }
}
