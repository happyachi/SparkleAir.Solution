using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.EFModel.EFModels;
using SparkleAir.Infa.Entity.AirFlightsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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
            var id = db.AirTypes.Select(t => t.FlightModel).FirstOrDefault();
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
                return (flightModel ?? "", "");
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
                DepartureAirport = db.AirPorts.Find(afm.DepartureAirportId).Lata,
                ArrivalAirport = db.AirPorts.Find(afm.ArrivalAirportId).Lata,
                DepartureTimeZone = db.AirPorts.Find(afm.DepartureAirportId).TimeArea,
                ArrivalTimeZone = db.AirPorts.Find(afm.ArrivalAirportId).TimeArea,
                AirOwnId = afm.AirFlights.GetAirOwnId(),
                FlightModel = db.GetFlightModelByAirOwnId(afm.AirFlights.GetAirOwnId()).Item1,
                CrossDay = afm.CrossDay
            };
            return entity;
        }
        public static EachSeatInfoEntity ToEachSeatInfoEntity(this AirBookSeat airBookSeat, int seatId)
        {
            EachSeatInfoEntity entity = new EachSeatInfoEntity
            {

                AirFlightSeatId = seatId,
                TicketInvoicingDetailId = airBookSeat.TicketInvoicingDetailId,
                ReservationTime = airBookSeat.ReservationTime,
                TransferPaymentId = airBookSeat.TransferPaymentId,
                HandlingFee = airBookSeat.HandlingFee,
                SeatAssignmentNum = airBookSeat.SeatAssignmentNum,
                SeatNum = airBookSeat.AirFlightSeat.SeatNum,
                LastName = airBookSeat.TicketInvoicingDetail.LastName,
                FirstName = airBookSeat.TicketInvoicingDetail.FirstName,
                Country = airBookSeat.TicketInvoicingDetail.Country.ChineseName,
                Gender = airBookSeat.TicketInvoicingDetail.Gender.ToString(),
                TypeofPassenger = airBookSeat.TicketInvoicingDetail.TicketDetail.TypeofPassenger.PassengerType,
                CheckInstatus = airBookSeat.TicketInvoicingDetail.CheckInStatus.ToString()
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
            for (int month = currentMonth; month <= (currentMonth)+1; month++)
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
                FlightModel = af.AirOwn.AirType.FlightModel,
                FlightCode = af.AirFlightManagement.FlightCode,
                DepartureAirport = db.AirPorts.Find(af.AirFlightManagement.DepartureAirportId).Lata,
                ArrivalAirport = db.AirPorts.Find(af.AirFlightManagement.ArrivalAirportId).Lata,
                DepartureAirportId = db.GetFlightCode(af.AirFlightManagementId).Item1,
                ArrivalAirportId = db.GetFlightCode(af.AirFlightManagementId).Item2,
                DepartureTimeZone = db.AirPorts.Find(af.AirFlightManagement.DepartureAirportId).TimeArea,
                ArrivalTimeZone = db.AirPorts.Find(af.AirFlightManagement.ArrivalAirportId).TimeArea,
                AirFlightSaleStatus = af.AirFlightSaleStatus.Status,
                DayofWeek = af.AirFlightManagement.DayofWeek,
                RegistrationNum = af.AirOwn.RegistrationNum
            };
            return entity;
        }
        public static string GetSaleStatus(this int statusId, AppDbContext db)
        {
            var status = db.AirFlightSaleStatuses.Find(statusId);
            return status.Status;
        }
        //取得ToAirFlightEntity所需相關訊息
        //出發地ID 目的地ID
        public static (int, int) GetFlightCode(this AppDbContext db, int id)
        {
            var data = db.AirFlightManagements.Find(id);
            return (data.DepartureAirportId, data.ArrivalAirportId);
        }

        public static AirFlightSeatsEntity ToFlightSeatsEntity(this AirFlightSeat seats, int airFlightId)
        {
            AirFlightSeatsEntity entity = new AirFlightSeatsEntity
            {
                Id = seats.Id,
                AirFlightId = airFlightId,
                AirCabinId = seats.AirCabinId,
                IsSeated = seats.IsSeated,
                SeatNum = seats.SeatNum,
                CabinName = seats.AirCabin.CabinClass,
                FlightModel = seats.AirFlight.AirOwn.AirType.FlightModel,
                RegisterNum = seats.AirFlight.AirOwn.RegistrationNum
            };
            return entity;
        }
    }
}
