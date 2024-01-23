using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SparkleAir.Infa.Utility.Exts.Models;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightEFRepository : IAirFlightRepository
    {
        AppDbContext db = new AppDbContext();

        private Func<int, AppDbContext, string> airport = (a, db) =>
        {
            return db.AirPorts.Find(a).Lata;
        };

        public int Create(AirFlightManagementEntity entity)
        {
            AirFlightManagement airFlight = entity.ToModel();

            db.AirFlightManagements.Add(airFlight);
            db.SaveChanges();

            return airFlight.Id;
        }

        public void Delete(int id)
        {
            var flight = db.AirFlightManagements.Find(id);

            db.AirFlightManagements.Remove(flight);

            db.SaveChanges();
        }

        public List<AirFlightManagementEntity> GetAll()
        {
            var flights = db.AirFlightManagements
                .AsNoTracking()
                .Include(a => a.AirPort)
                .ToList()
                .Select(a => new AirFlightManagementEntity
                {
                    Id = a.Id,
                    FlightCode = a.FlightCode,
                    DepartureAirportId = a.DepartureAirportId,
                    DestinationAirportId = a.DestinationAirportId,
                    DepartureTerminal = a.DepartureTerminal,
                    DestinationTerminal = a.DestinationTerminal,
                    DepartureTime = a.DepartureTime,
                    ArrivalTime = a.ArrivalTime,
                    DayofWeek = a.DayofWeek,
                    Mile = a.Mile,
                    DepartureAirport = airport(a.DepartureAirportId, db),
                    DestinationAirport = airport(a.DestinationAirportId, db)
                })
                .ToList();

            return flights;
        }

        public AirFlightManagementEntity GetById(int id)
        {
            var flight = db.AirFlightManagements
                .Find(id);
            var airplain = new AirFlightManagementEntity
            {
                Id = flight.Id,
                FlightCode = flight.FlightCode,
                DepartureAirportId = flight.DepartureAirportId,
                DestinationAirportId = flight.DestinationAirportId,
                DepartureTerminal = flight.DepartureTerminal,
                DestinationTerminal = flight.DestinationTerminal,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                DayofWeek = flight.DayofWeek,
                Mile = flight.Mile,
                DepartureAirport = airport(flight.DepartureAirportId, db),
                DestinationAirport = airport(flight.DestinationAirportId, db)
            };

            return airplain;
        }

        public void Update(AirFlightManagementEntity entity)
        {
            var flight = db.AirFlightManagements
                .FirstOrDefault(f => f.Id == entity.Id);

            if (flight != null)
            {
                flight.FlightCode = entity.FlightCode;
                flight.DepartureAirportId = entity.DepartureAirportId;
                flight.DestinationAirportId = entity.DestinationAirportId;
                flight.DepartureTerminal = entity.DepartureTerminal;
                flight.DestinationTerminal = entity.DestinationTerminal;
                flight.DepartureTime = entity.DepartureTime;
                flight.ArrivalTime = entity.ArrivalTime;
                flight.DayofWeek = entity.DayofWeek;
                flight.Mile = entity.Mile;

                db.SaveChanges();
            }
        }

        public List<AirFlightManagementEntity> Search(AirFlightManagementEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
