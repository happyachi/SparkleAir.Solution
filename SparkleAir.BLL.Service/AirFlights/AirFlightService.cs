﻿using SparkleAir.IDAL.IRepository.AirFlights;
using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using SparkleAir.Infa.Utility.Exts.Models;
using SparkleAir.Infa.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.BLL.Service.AirFlights
{
    public class AirFlightService
    {
        private readonly IAirFlightRepository _repo;
        public AirFlightService(IAirFlightRepository repo)
        {
            _repo = repo;
        }
        public void Create(AirFlightDto dto)
        {
            FlightDate[] days = dto.DayofWeek.FlightDays();
            var today = DateTime.Today;
            int thisMonth = today.Month;
            int thisYear = today.Year;
            DateTime currentDate = new DateTime(thisYear, thisMonth, 1);
            List<DateTime> scheduledFlights = currentDate.GetScheduledFlights(days, today);

            foreach (var scheduledFlight in scheduledFlights)
            {
                // 將起飛時間和抵達時間與日期結合
                DateTime scheduledDeparture = scheduledFlight.Date + TimeZoneHelper.ConvertToGMT(dto.ScheduledDeparture.TimeOfDay,dto.DepartureTimeZone);
                DateTime scheduledArrival = scheduledFlight.Date + TimeZoneHelper.ConvertToGMT(dto.ScheduledArrival.TimeOfDay,dto.ArrivalTimeZone);

                AirFlightEntity entity = new AirFlightEntity
                {
                    Id = dto.Id,
                    AirOwnId = dto.AirOwnId,
                    FlightCode = dto.FlightCode,
                    FlightModel = dto.FlightModel,
                    DepartureAirport = dto.DepartureAirport,
                    ArrivalAirport = dto.ArrivalAirport,
                    AirFlightManagementId = dto.AirFlightManagementId,
                    AirFlightSaleStatusId = dto.AirFlightSaleStatusId,
                    AirFlightSaleStatus = dto.AirFlightSaleStatus,
                    DayofWeek = dto.DayofWeek,
                    ScheduledDeparture = scheduledDeparture,
                    ScheduledArrival = scheduledArrival
                };

                _repo.Create(entity);
            }
        }

        public AirFlightDto GetById(int id)
        {
            var entity = _repo.GetById(id);
            AirFlightDto dto = new AirFlightDto
            {
                Id = entity.Id,
                AirOwnId = entity.AirOwnId,
                AirFlightManagementId = id,
                ScheduledDeparture = entity.ScheduledDeparture,
                ScheduledArrival = entity.ScheduledArrival,
                AirFlightSaleStatusId = entity.AirFlightSaleStatusId,
                FlightModel = entity.FlightModel,
                FlightCode = entity.FlightCode,
                DepartureAirport = entity.DepartureAirport,
                ArrivalAirport = entity.ArrivalAirport,
                AirFlightSaleStatus = entity.AirFlightSaleStatus,
            };

            return dto;
        }
    }
}
