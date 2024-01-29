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
        //用lata取得Id
        public static int GetAirportId(this string lata, AppDbContext db)
        {
            var data = db.AirPorts.FirstOrDefault(airPort => airPort.Lata == lata);
            return data.Id;
        }

        //用Id取得Lata
        public static (string, int) GetAirport(this int airportId, AppDbContext db)
        {
            var data = db.AirPorts.Find(airportId);

            return (data.Lata, data.TimeArea);
        }

        //取得AirOwnId 給 ToAirFlightManagementEntity 用的
        public static int? GetAirOwnId(this IEnumerable<AirFlight> airFlights)
        {
            return airFlights?.Select(f => f.AirOwnId).FirstOrDefault();
        }

        //取得AirOwnId 給 EF 用的
        public static int? GetAirOwnIdByFlightModel(this string flightModel, AppDbContext db)
        {
            var airOwnId = db.AirOwns
                              .Join(db.AirTypes, ao => ao.AirTypeId, airtype => airtype.Id, (ao, airtype) => new { ao, airtype.FlightModel })
                              .Where(joined => joined.FlightModel == flightModel)
                              .Select(joined => (int?)joined.ao.Id)
                              .FirstOrDefault();

            return airOwnId;
        }

        //取得FlightModel
        public static (string, string) GetFlightModelByAirOwnId(this AppDbContext db, int? airOwnId)
        {
            var flightModel = db.AirOwns
                            .Where(ao => ao.Id == airOwnId)
                            .Join(db.AirTypes, ao => ao.AirTypeId, ty => ty.Id, (ao, ty) => ty.FlightModel)
                            .FirstOrDefault();
            var num = db.AirOwns.Where(ao => ao.Id == airOwnId).FirstOrDefault();
            if (num == null)
            {
                return (flightModel?? "", "");
            }
            else
            {
            return (flightModel ?? "", num.RegistrationNum);
            }
        }

        //轉換AirFlightManagement To AirFlightManagementEntity
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
                FlightModel = db.GetFlightModelByAirOwnId(afm.AirFlights.GetAirOwnId()).Item1,
            };
            return entity;
        }

        //用迴圈跑值班表(一個月內的)
        //todo 可以設定要跑出多久之後的班表
        public static List<DateTime> GetScheduledFlights(this DateTime currentDate, FlightDate[] days, DateTime today)
        {
            var scheduledFlights = new List<DateTime>();
            var currentMonth = currentDate.Month;
            //var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            //var daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            for (int month = currentMonth; month <= (currentMonth); month++)
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

        //轉換AirFlight To AirFlightEntity
        public static AirFlightEntity ToAirFlightEntity(this AirFlight af)
        {
            AppDbContext db = new AppDbContext();
            AirFlightEntity entity = new AirFlightEntity
            {
                Id = af.Id,
                AirOwnId = af.AirOwnId,
                AirFlightManagementId = af.AirFlightManagementId,
                ScheduledDeparture = af.ScheduledDeparture,
                ScheduledArrival = af.ScheduledArrival,
                AirFlightSaleStatusId = af.AirFlightSaleStatusId,
                FlightModel = db.GetFlightModelByAirOwnId(af.AirOwnId).Item1,
                FlightCode = db.GetFlightCode(af.AirFlightManagementId).Item3,
                DepartureAirport = db.GetFlightCode(af.AirFlightManagementId).Item6,
                ArrivalAirport = db.GetFlightCode(af.AirFlightManagementId).Item7,
                DepartureAirportId = db.GetFlightCode(af.AirFlightManagementId).Item1,
                ArrivalAirportId = db.GetFlightCode(af.AirFlightManagementId).Item2,
                DepartureTimeZone = db.GetFlightCode(af.AirFlightManagementId).Item4,
                ArrivalTimeZone = db.GetFlightCode(af.AirFlightManagementId).Item5,
                AirFlightSaleStatus = af.AirFlightSaleStatusId.GetSaleStatus(db),
                DayofWeek = db.GetFlightCode(af.AirFlightManagementId).Item8,
                RegistrationNum = db.GetFlightModelByAirOwnId(af.AirOwnId).Item2
            };
            return entity;
        }
        public static string GetSaleStatus(this int statusId, AppDbContext db)
        {
            var status = db.AirFlightSaleStatuses.Find(statusId);
            return status.Status;
        }
        //取得ToAirFlightEntity所需相關訊息
        public static (int, int, string, int, int, string, string, string) GetFlightCode(this AppDbContext db, int id)
        {
            //出發地ID 目的地ID 航班編號 出發地時區 目的地時區 出發地機場 目的地機場,執飛日
            var data = db.AirFlightManagements.Find(id);
            var departureAirport = data.DepartureAirportId.GetAirport(db);
            var arrivarAirport = data.ArrivalAirportId.GetAirport(db);
            return (data.DepartureAirportId, data.ArrivalAirportId, data.FlightCode, departureAirport.Item2, arrivarAirport.Item2, departureAirport.Item1, arrivarAirport.Item1, data.DayofWeek);
        }
    }
}
