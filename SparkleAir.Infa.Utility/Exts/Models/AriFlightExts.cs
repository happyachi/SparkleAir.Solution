using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Exts.Models
{
	public static class AriFlightExts
    {
        public static AirFlightManagementEntity ToEntity(this AirFlightManagement airFlight)
		{
			AirFlightManagementEntity entity = new AirFlightManagementEntity
			{
				Id = airFlight.Id,
				FlightCode = airFlight.FlightCode,
				DepartureAirportId = airFlight.DepartureAirportId,
				ArrivalAirportId = airFlight.ArrivalAirportId,
				DepartureTerminal = airFlight.DepartureTerminal,
				ArrivalTerminal = airFlight.ArrivalTerminal,
				DepartureTime = airFlight.DepartureTime,
				ArrivalTime = airFlight.ArrivalTime,
				DayofWeek = airFlight.DayofWeek,
				Mile = airFlight.Mile,
			};
			return entity;
		}

		public static AirFlightManagement ToModel(this AirFlightManagementEntity entity)
		{
			AirFlightManagement airFlight = new AirFlightManagement
			{
				Id = entity.Id,
				FlightCode = entity.FlightCode,
				DepartureAirportId = entity.DepartureAirportId,
                ArrivalAirportId = entity.ArrivalAirportId,
				DepartureTerminal = entity.DepartureTerminal,
				ArrivalTerminal = entity.ArrivalTerminal,
				DepartureTime = entity.DepartureTime,
				ArrivalTime = entity.ArrivalTime,
				DayofWeek = entity.DayofWeek,
				Mile = entity.Mile
			};
			return airFlight;
		}

        public static int GetAirportId(this string lata, AppDbContext db)
        {
            var data = db.AirPorts.FirstOrDefault(airPort => airPort.Lata == lata);
            return data.Id;
        }

        public static (string, int) GetAirport(this int airportId, AppDbContext db)
        {
            var data = db.AirPorts.Find(airportId);

            return (data.Lata, data.TimeArea);
        }

        //public static Func<int, AppDbContext, (string, int)> airport = (a, db) =>
        //{
        //    var datas = db.AirPorts.Find(a);

        //    return (datas.Lata, datas.TimeArea);
        //};

        //public static Func<string, AppDbContext, int> airportId = (a, db) =>
        //{
        //    var data = db.AirPorts.Where(AirPort => a == AirPort.Lata).FirstOrDefault().Id;

        //    return data;
        //};
    }
}
