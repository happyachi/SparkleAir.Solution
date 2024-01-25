using SparkleAir.Infa.Dto.AriFlights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.Infa.Utility.Helper
{
    public enum FlightDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }
    public static class SplitFlightDaysHelper
    {
        public static FlightDays FlightDays(this string flightDays)
        {
            var dayNumbers = flightDays.Split(',').Select(int.Parse);

            // 將數字轉換為列舉值
            var days = (FlightDays)dayNumbers.Sum();

            return days;
        }
    }
}
