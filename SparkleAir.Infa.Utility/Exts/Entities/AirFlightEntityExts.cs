﻿using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Exts.Entities
{
	public static class AirFlightEntityExts
	{
		public static AirFlightManagementDto ToDto(this AirFlightManagementEntity entity)
		{
			AirFlightManagementDto dto = new AirFlightManagementDto
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
			return dto;
		}

		public static AirFlightManagementEntity ToEntity(this AirFlightManagementDto dto)
		{
			AirFlightManagementEntity entity = new AirFlightManagementEntity
			{
				Id = dto.Id,
				FlightCode = dto.FlightCode,
				DepartureAirportId = dto.DepartureAirportId,
				DestinationAirportId = dto.DestinationAirportId,
				DepartureTerminal = dto.DepartureTerminal,
				DestinationTerminal = dto.DestinationTerminal,
				DepartureTime = dto.DepartureTime,
				ArrivalTime = dto.ArrivalTime,
				DayofWeek = dto.DayofWeek,
				Mile = dto.Mile
			};
			return entity;
		}

	}
}
