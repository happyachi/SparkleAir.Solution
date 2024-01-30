using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using SparkleAir.Infa.Utility.Exts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightEFRepository : IAirFlightRepository
    {
        private AppDbContext db = new AppDbContext();
        private Func<AirFlight, AirFlightEntity> ToEntityFunc = (f) => f.ToAirFlightEntity();

        public int Create(AirFlightEntity entity)
        {
            AirFlight airFlight = new AirFlight
            {
                Id = entity.Id,
                AirOwnId = (int)entity.FlightModel.GetAirOwnIdByFlightModel(db),
                AirFlightManagementId = entity.AirFlightManagementId,
                ScheduledDeparture = entity.ScheduledDeparture,
                ScheduledArrival = entity.ScheduledArrival,
                AirFlightSaleStatusId = entity.AirFlightSaleStatusId
            };
            db.AirFlights.Add(airFlight);
            db.SaveChanges();
            var id = airFlight.Id;
            return id;
        }

        public List<AirFlightEntity> GetAll()
        {
            var flights = db.AirFlights
                .AsNoTracking()
                .Include(x => x.AirOwn)
                .Include(x => x.AirFlightManagement)
                .Include(x => x.AirFlightManagement.AirPort)
                .Include(x => x.AirOwn.AirType)
                .Include(x => x.AirFlightSaleStatus)
                .ToList()
                .Select(ToEntityFunc)
                .ToList();
            return flights;
        }

        public AirFlightEntity GetById(int id)
        {
            var flight = db.AirFlights
                .Find(id)
                .ToAirFlightEntity();

            return flight;
        }
    }
}
