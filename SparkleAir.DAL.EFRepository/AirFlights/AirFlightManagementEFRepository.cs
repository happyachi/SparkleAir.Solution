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

        private Func<int, AppDbContext, (string, int)> airport = (a, db) =>
        {
            var datas = db.AirPorts.Find(a);

            return (datas.Lata, datas.TimeArea);
        };

        private Func<string, AppDbContext, int> airportId = (a, db) =>
        {
            var data = db.AirPorts.Where(AirPort => a == AirPort.Lata).FirstOrDefault().Id;

            return data;
        };

        public int Create(AirFlightManagementEntity entity)
        {
            AirFlightManagement airFlight = new AirFlightManagement
            {
                FlightCode = entity.FlightCode,
                DepartureAirportId = airportId(entity.DepartureAirport, db),
                ArrivalAirportId= airportId(entity.ArrivalAirport, db),
                DepartureTerminal = entity.DepartureTerminal,
                ArrivalTerminal = entity.ArrivalTerminal,
                DepartureTime = entity.DepartureTime,
                ArrivalTime = entity.ArrivalTime,
                DayofWeek = entity.DayofWeek,
                Mile = entity.Mile,
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
                .ToList()
                .Select(a => new AirFlightManagementEntity
                {
                    Id = a.Id,
                    FlightCode = a.FlightCode,
                    DepartureAirportId = a.DepartureAirportId,
                    ArrivalAirportId = a.ArrivalAirportId,
                    DepartureTerminal = a.DepartureTerminal,
                    ArrivalTerminal = a.ArrivalTerminal,
                    DepartureTime = a.DepartureTime,
                    ArrivalTime = a.ArrivalTime,
                    DayofWeek = a.DayofWeek,
                    Mile = a.Mile,
                    DepartureAirport = airport(a.DepartureAirportId, db).Item1,
                    ArrivalAirport = airport(a.ArrivalAirportId, db).Item1,
                    DepartureTimeZone = airport(a.DepartureAirportId, db).Item2,
                    ArrivalTimeZone = airport(a.ArrivalAirportId, db).Item2
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
                ArrivalAirportId = flight.ArrivalAirportId,
                DepartureTerminal = flight.DepartureTerminal,
                ArrivalTerminal = flight.ArrivalTerminal,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                DayofWeek = flight.DayofWeek,
                Mile = flight.Mile,
                DepartureAirport = airport(flight.DepartureAirportId, db).Item1,
                ArrivalAirport = airport(flight.ArrivalAirportId, db).Item1,
                DepartureTimeZone = airport(flight.DepartureAirportId, db).Item2,
                ArrivalTimeZone = airport(flight.ArrivalAirportId, db).Item2
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
                flight.DepartureAirportId = airportId(entity.DepartureAirport, db);
                flight.ArrivalAirportId = airportId(entity.ArrivalAirport, db);
                flight.DepartureTerminal = entity.DepartureTerminal;
                flight.ArrivalTerminal = entity.ArrivalTerminal;
                flight.DepartureTime = entity.DepartureTime;
                flight.ArrivalTime = entity.ArrivalTime;
                flight.DayofWeek = entity.DayofWeek;
                flight.Mile = entity.Mile;
            }
            db.SaveChanges();
        }

        public List<AirFlightManagementEntity> Search(AirFlightManagementSearch entity)
        {
            var query = db.AirFlightManagements.AsNoTracking().Include(a => a.AirPort).ToList().Select(a => new AirFlightManagementEntity
            {
                Id = a.Id,
                FlightCode = a.FlightCode,
                DepartureAirportId = a.DepartureAirportId,
                ArrivalAirportId = a.ArrivalAirportId,
                DepartureTerminal = a.DepartureTerminal,
                ArrivalTerminal = a.ArrivalTerminal,
                DepartureTime = a.DepartureTime,
                ArrivalTime = a.ArrivalTime,
                DayofWeek = a.DayofWeek,
                Mile = a.Mile,
                DepartureAirport = airport(a.DepartureAirportId, db).Item1,
                ArrivalAirport = airport(a.ArrivalAirportId, db).Item1,
                DepartureTimeZone = airport(a.DepartureAirportId, db).Item2,
                ArrivalTimeZone = airport(a.ArrivalAirportId, db).Item2
            });

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
            if(entity.DepartureEndTime != default(TimeSpan))
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
