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
				DestinationAirportId = airFlight.DestinationAirportId,
				DepartureTerminal = airFlight.DepartureTerminal,
				DestinationTerminal = airFlight.DestinationTerminal,
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
				DestinationAirportId = entity.DestinationAirportId,
				DepartureTerminal = entity.DepartureTerminal,
				DestinationTerminal = entity.DestinationTerminal,
				DepartureTime = entity.DepartureTime,
				ArrivalTime = entity.ArrivalTime,
				DayofWeek = entity.DayofWeek,
				Mile = entity.Mile
			};
			return airFlight;
		}
	}
}
