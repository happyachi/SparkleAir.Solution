using SparkleAir.Infa.Criteria.AirFlights;
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

        public static int? GetAirOwnId(this IEnumerable<AirFlight> airFlights)
        {
            return airFlights?.Select(f => f.AirOwnId).FirstOrDefault();
        }

        public static int? GetAirOwnIdByFlightModel(this string flightModel, AppDbContext db)
        {
            var airOwnId = db.AirOwns
                              .Join(db.AirTypes, ao => ao.AirTypeId, airtype => airtype.Id, (ao, airtype) => new { ao, airtype.FlightModel })
                              .Where(joined => joined.FlightModel == flightModel)
                              .Select(joined => (int?)joined.ao.Id)
                              .FirstOrDefault();

            return airOwnId;
        }

        //public static string GetFlightModel(this int? airownId, AppDbContext db)
        //{
        //    var flightModel = db.AirOwns
        //            .Where(ao => ao.Id == airownId)
        //            .Join(db.AirFlights, ao => ao.Id, af => af.AirOwnId, (ao, af) => new { ao, af })
        //            .Join(db.AirFlightManagements, a => a.af.AirFlightManagementId, afm => afm.Id, (a, afm) => afm)
        //            .Select(a => a.AirTypeId) // 選擇 AirTypeId
        //            .Join(db.AirTypes, airTypeId => airTypeId, airtype => airtype.Id, (airTypeId, airtype) => airtype.FlightModel)
        //            .FirstOrDefault();

        //    return flightModel ?? "";
        //}

        public static string GetFlightModelByAirOwnId(this AppDbContext db, int? airOwnId)
        {
            var flightModel = db.AirOwns
                            .Where(ao => ao.Id == airOwnId)
                            .Join(db.AirTypes, ao => ao.AirTypeId, ty => ty.Id, (ao, ty) => ty.FlightModel)
                            .FirstOrDefault();

            return flightModel ?? "";
        }

        //AirFlightManagement To AirFlightManagementEntity
        public static AirFlightManagementEntity ToAirFlightManagementEntity(this AirFlightManagement afm)
        {
            AppDbContext db = new AppDbContext();
            AirFlightManagementEntity entity = new AirFlightManagementEntity
            {
                Id = afm.Id,
                FlightCode = afm.FlightCode,
                DepartureAirportId = afm.DepartureAirportId,
                ArrivalAirportId = afm.ArrivalAirportId,
                ArrivalTerminal = afm.ArrivalTerminal,
                DepartureTime = afm.DepartureTime,
                ArrivalTime = afm.ArrivalTime,
                DayofWeek = afm.DayofWeek,
                Mile = afm.Mile,
                DepartureAirport = afm.DepartureAirportId.GetAirport(db).Item1,
                ArrivalAirport = afm.ArrivalAirportId.GetAirport(db).Item1,
                DepartureTimeZone = afm.DepartureAirportId.GetAirport(db).Item2,
                ArrivalTimeZone = afm.ArrivalAirportId.GetAirport(db).Item2,
                AirOwnId = afm.AirFlights.GetAirOwnId(),
                FlightModel = db.GetFlightModelByAirOwnId(afm.AirFlights.GetAirOwnId()),
            };
            return entity;
        }

        //用迴圈跑值班表
        public static List<DateTime> GetScheduledFlights(this DateTime currentDate, FlightDate[] days, DateTime today)
        {
            var scheduledFlights = new List<DateTime>();
            var currentMonth = currentDate.Month;
            //var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            //var daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            for (int month = currentMonth; month <= (currentMonth + 1); month++)
            {
                var daysInMonth = DateTime.DaysInMonth(currentDate.Year, month);
                for (int day = 1; day <= daysInMonth; day++)
                {
                    var currentDay = new DateTime(currentDate.Year, month, day);

                    foreach (var flightDay in days)
                    {
                        // 將使用者輸入的數字 7 轉換為 DayOfWeek.Sunday
                        DayOfWeek userDayOfWeek = (DayOfWeek)((int)flightDay % 7);

                        if ((userDayOfWeek == currentDay.DayOfWeek) && currentDay >= today)
                        {
                            scheduledFlights.Add(currentDay);
                            break; // 如果符合條件，跳出內層迴圈，繼續處理下一天
                        }
                    }
                }
            }
            return scheduledFlights;
        }
    }
}
