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
using SparkleAir.Infa.Criteria.AirFlights;

namespace SparkleAir.DAL.EFRepository.AirFlights
{
    public class AirFlightManagementEFRepository : IAirFlightManagementRepository
    {
        AppDbContext db = new AppDbContext();

        private Func<AirFlightManagement, AirFlightManagementEntity> ToEntityFunc = (e) => e.ToAirFlightManagementEntity();

        public int Create(AirFlightManagementEntity entity)
        {
            AirFlightManagement airFlight = new AirFlightManagement
            {
                FlightCode = entity.FlightCode,
                DepartureAirportId = entity.DepartureAirport.GetAirportId(db),
                ArrivalAirportId = entity.ArrivalAirport.GetAirportId(db),
                DepartureTerminal = entity.DepartureTerminal,
                ArrivalTerminal = entity.ArrivalTerminal,
                DepartureTime = entity.DepartureTime,
                ArrivalTime = entity.ArrivalTime,
                DayofWeek = entity.DayofWeek,
                Mile = entity.Mile,
                CrossDay = entity.CrossDay
            };

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
                .Include(a => a.AirFlights)
                .ToList()
                .Select(ToEntityFunc)
                .ToList();

            return flights;
        }

        public AirFlightManagementEntity GetById(int id)
        {
            var flight = db.AirFlightManagements
                .Find(id);
            var airplain = ToEntityFunc(flight);

            return airplain;
        }

        public void Update(AirFlightManagementEntity entity)
        {
            var flight = db.AirFlightManagements
                .Include(f => f.AirPort)
                .FirstOrDefault(f => f.Id == entity.Id);

            if (flight != null)
            {
                flight.FlightCode = entity.FlightCode;
                flight.DepartureAirportId = entity.DepartureAirport.GetAirportId(db);
                flight.ArrivalAirportId = entity.ArrivalAirport.GetAirportId(db);
                flight.DepartureTerminal = entity.DepartureTerminal;
                flight.ArrivalTerminal = entity.ArrivalTerminal;
                flight.DepartureTime = entity.DepartureTime;
                flight.ArrivalTime = entity.ArrivalTime;
                flight.DayofWeek = entity.DayofWeek;
                flight.Mile = entity.Mile;
                flight.CrossDay = entity.CrossDay;
            }
            db.SaveChanges();
        }

        public List<AirFlightManagementEntity> Search(AirFlightManagementSearchCriteria entity)
        {
            var query = db.AirFlightManagements.AsNoTracking().Include(a => a.AirPort).ToList().Select(ToEntityFunc);

            if (!string.IsNullOrEmpty(entity.FlightCode))
            {
                query = query.Where(e => e.FlightCode.Contains(entity.FlightCode));
            }

            if (!string.IsNullOrEmpty(entity.DepartureAirport))
            {
                query = query.Where(e => e.DepartureAirport == entity.DepartureAirport);
            }

            if (!string.IsNullOrEmpty(entity.ArrivalAirport))
            {
                query = query.Where(e => e.ArrivalAirport == entity.ArrivalAirport);
            }

            if (entity.DepartureStartTime != default(TimeSpan))
            {
                query = query.Where(e => e.DepartureTime >= entity.DepartureStartTime);
            }
            if (entity.DepartureEndTime != default(TimeSpan))
            {
                query = query.Where(e => e.DepartureTime <= entity.DepartureEndTime);
            }
            if (entity.ArrivalStartTime != default(TimeSpan))
            {
                query = query.Where(e => e.ArrivalTime >= entity.ArrivalStartTime);
            }
            if (entity.ArrivalEndTime != default(TimeSpan))
            {
                query = query.Where(e => e.DepartureTime <= entity.ArrivalEndTime);
            }
            return query.ToList();
        }
    }
}
