using SparkleAir.Infa.Criteria.AirFlights;
using SparkleAir.Infa.Dto.AriFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Helper
{

    public static class SplitFlightDaysHelper
    {
        public static FlightDate FlightDays(this string flightDays)
        {
            var dayNumbers = flightDays.Split(',').Select(int.Parse);

            // 將數字轉換為列舉值
            var days = (FlightDate)dayNumbers.Sum();

            return days;
        }
    }
}
